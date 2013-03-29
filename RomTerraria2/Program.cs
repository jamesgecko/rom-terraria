using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace RomTerraria
{
    static class Program
    {
        static string GamePath = "";

        static List<string> FindDetails = new List<string>();

        static List<Process> GetProcessesByName(string machine, string filter, RegexOptions options)
        {
            List<Process> processList = new List<Process>();

            // Get the current processes
            Process[] runningProcesses = Process.GetProcesses(machine);

            // Find those that match the specified regular expression
            Regex processFilter = new Regex(filter, options);
            foreach (Process current in runningProcesses)
            {
                // Check for a match.
                if (processFilter.IsMatch(current.ProcessName))
                {
                    processList.Add(current);
                }
                // Dispose of any we're not keeping
                else current.Dispose();
            }

            // Return the filtered list as an array
            return processList;
        }

        static bool FindGame()
        {
            var steamCandidates = GetProcessesByName(".", "steam", RegexOptions.IgnoreCase);
            foreach (var p in steamCandidates)
            {
                try
                {
                    if (p.MainModule.ModuleName.ToLower() == "steam.exe")
                    {
                        FindDetails.Add("Steam.exe process found.");
                        FileInfo f = new FileInfo(p.MainModule.FileName);
                        var d = f.Directory.GetDirectories("steamapps");
                        if (d.Count() > 0)
                        {
                            FindDetails.Add("Steamapps folder found.");
                            d = d[0].GetDirectories("common");
                            if (d.Count() > 0)
                            {
                                FindDetails.Add("Common folder found.");
                                d = d[0].GetDirectories("terraria");
                                if (d.Count() > 0)
                                {
                                    FindDetails.Add("Terraria folder found.");
                                    GamePath = d[0].FullName;
                                    return true;
                                }
                            }
                        }
                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    // Ignore this...means we were looking at SteamService.
                }
            }

            if (FindDetails.Count == 0)
            {
                FindDetails.Add("Could not find a process named Steam.exe running.");
            }
            return false;
        }

        const string TestVersionWarining =
            @"This is a pre-release version of the RomTerraria launcher.  Many features may not work.
If you are using this launcher, you have been asked to test specific functionality.  Please reply to the appropriate thread on Shacknews with feedback on that functionality.
Do not ask others to use this launcher without pointing them to that thread, and don't redistribute this yet.
Do you agree to these terms?
";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!FindGame())
            {
                FindDetails.Insert(0, "Unable to find Terraria.  Make sure Steam is running.  Details:");
                MessageBox.Show(String.Join("\n", FindDetails.ToArray()));
                return;
            }
            
            Directory.SetCurrentDirectory(GamePath);

            SetupTerrariaForLoad();

#if false

            if (MessageBox.Show(TestVersionWarining, "Test Version Of RomTerraria", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
#endif
            try
            {
                using (Launcher l = new Launcher())
                {
                    var dr = l.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        // I have to do this song-and-dance routine in order to late-bind Terraria but still strongly type it in GameLauncher
                        var t = Assembly.GetExecutingAssembly().GetType("RomTerraria.GameLauncher", true, true);
                        var launcher = Activator.CreateInstance(t) as Game;
                        
                        if (launcher != null)
                        {
                            // Set up options not included in the settings

                            GameSettings.Path = GamePath;
                            GameSettings.CreateCraftableList = l.CreateCraftableList;
                            GameSettings.Rain = l.Rain;
                            GameSettings.Lava = l.Lava;
                            GameSettings.RainfallRate = 
                                GameSettings.LavafallRate = l.RainfallRate;
                            GameSettings.WaterInHell = l.WaterInHell;
                            GameSettings.InfiniteBloodMoon = l.InfiniteBloodMoon;
                            GameSettings.InfiniteGoblinInvasion = l.InfiniteGoblinInvasion;
                            GameSettings.SpawnEye = l.SpawnEye;
                            GameSettings.LavaCleanup = l.LavaCleanup;
                            launcher.Run();
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                if (!Debugger.IsAttached)
                {
                    string fn = String.Format(@"{0}\My Games\Terraria\Stack Traces\RomTerraria-{1:yyyyMMddhhmmss}.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DateTime.UtcNow);

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    while (ex != null)
                    {
                        sb.AppendFormat("[{0}] {1}\n\n{2}\n\n", ex.GetType(), ex.Message, ex.StackTrace);
                        ex = ex.InnerException;
                    }

                    string stacktrace = sb.ToString();
                    using (StreamWriter sr = new StreamWriter(fn))
                    {
                        sr.Write(stacktrace);
                    }
                    MessageBox.Show(stacktrace, String.Format("{0} {1}", Application.ProductName, Application.ProductVersion));
                }
                else
                {
                    throw;
                }
            }

            finally
            {

            }
        }

        private static void SetupTerrariaForLoad()
        {

            Assembly assm = Assembly.GetExecutingAssembly();
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            // This fixes the "settings don't save" bug that still exists in 1.0.5
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria");

            // While we're here, let's get some stuff set up
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Texture Packs");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Plugins");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Stack Traces");
        }

        // This is half the magic that lets us bind to an assembly that is outside our path.
        // Essentially, when .NET asks for the Terraria assembly, this function tells it to load
        // the assembly from the Steam folder as set in the GamePath variable.
        // Because of this, any add-ons cannot start with the word "Terraria" without
        // this function being rewritten.
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("Terraria"))
            {
                var file = GamePath + @"\Terraria.exe";
                var asm = Assembly.LoadFile(file);
                return asm;
            }
            return null;
        }



    }
}
