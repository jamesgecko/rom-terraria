using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RomTerraria.Properties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace RomTerraria
{
    public partial class Launcher : Form
    {
        Settings settings = new Settings();

        private void PopulateTexturePacks()
        {
            string detectPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Texture Packs";
            DirectoryInfo di = new DirectoryInfo(detectPath);
            texturePack.Items.Clear();
            foreach (var d in di.GetDirectories())
            {
                texturePack.Items.Add(new ListViewItem()
                {
                  ImageKey = "Folder",
                  Group = texturePack.Groups["folder"],
                  Text = d.Name,
                  Tag = d.FullName
                });
            }

            foreach (var f in di.GetFiles("*.zip"))
            {
                texturePack.Items.Add(new ListViewItem()
                {
                    ImageKey = "ZIP",
                    Group = texturePack.Groups["zip"],
                    Text = f.Name,
                    Tag = f.FullName
                });
            }

            foreach (ListViewItem li in texturePack.Items)
            {
                if (String.Compare(li.Tag.ToString(), settings.LastTexturePack, true) == 0)
                {
                    li.Selected = true;
                }
            }
        }
        public Launcher()
        {
            InitializeComponent();
            this.Text = String.Format("{0} v{1} - http://www.romsteady.net", Application.ProductName, Application.ProductVersion);
            gameWidth.Text = (Math.Max(800, settings.GameWidth)).ToString();
            gameHeight.Text = (Math.Max(600, settings.GameHeight)).ToString();

            switch (settings.GameResizeMode)
            {
                case 0: gameNoResize.Checked = true; break;
                case 1: gameMultimon.Checked = true; break;
                case 2: gameResize.Checked = true; break;
                default: gameNoResize.Checked = true; break;
            }

            useInternalFonts.Checked = settings.UseInternalFonts;
            useTexturePacks.Checked = settings.UseTexturePacks;
            PopulateTexturePacks();

            useHiDef.Checked = settings.UseHiDef;

            localMinimap.Checked = settings.LocalMinimap;
            globalMinimap.Checked = settings.GlobalMinimap;

            regenMana.Checked = settings.RegenMana;
            regenHealth.Checked = settings.RegenHealth;
            regenRate.Value = regenRate.Maximum - settings.RegenTimer;

            manaBoots.Checked = settings.ManaBoots;
            labelNPCRooms.Checked = settings.LabelNPCRooms;

            inGameClock.Checked = settings.InGameClock;
            profanityFilter.Checked = settings.ProfanityFilter;

            showTooltip.Checked = settings.ShowTooltip;

            resizeBackgrounds.Checked = settings.ResizeBackgrounds;
        }

        private void gameResize_CheckedChanged(object sender, EventArgs e)
        {
            labelHeight.Enabled = labelWidth.Enabled = gameHeight.Enabled = gameWidth.Enabled = gameResize.Checked;
        }

        private void useTexturePacks_CheckedChanged(object sender, EventArgs e)
        {
            texturePack.Enabled = useTexturePacks.Checked;
        }

        private void launch_Click(object sender, EventArgs e)
        {
            settings.GameResizeMode = gameResize.Checked ? 2 : gameMultimon.Checked ? 1 : 0;
            settings.UseTexturePacks = useTexturePacks.Checked;
            settings.UseInternalFonts = useInternalFonts.Checked;
            settings.LastTexturePack = (useTexturePacks.Checked && texturePack.SelectedItems.Count > 0) ? texturePack.SelectedItems[0].Tag.ToString() : "";
            int temp = 0;
            int.TryParse(gameWidth.Text, out temp);
            settings.GameWidth = Math.Max(temp, 800);
            int.TryParse(gameHeight.Text, out temp);
            settings.GameHeight = Math.Max(temp, 600);
            settings.UseHiDef = useHiDef.Checked;
            settings.LocalMinimap = localMinimap.Checked;
            settings.GlobalMinimap = globalMinimap.Checked;
            settings.RegenTimer = regenRate.Maximum - regenRate.Value;
            settings.ManaBoots = manaBoots.Checked;
            settings.LabelNPCRooms = labelNPCRooms.Checked;
            settings.RegenHealth = regenHealth.Checked;
            settings.RegenMana = regenMana.Checked;
            settings.InGameClock = inGameClock.Checked;
            settings.ProfanityFilter = profanityFilter.Checked;
            settings.ShowTooltip = showTooltip.Checked;
            settings.ResizeBackgrounds = resizeBackgrounds.Checked;
            settings.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        #region " Generate Default Texture Pack "

        private void generateDefault_Click(object sender, EventArgs e)
        {
            string outputPath =Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Texture Packs\Stock\Images";
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Texture Packs\Stock");
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\Terraria\Texture Packs\Stock\Fonts");
            Directory.CreateDirectory(outputPath);

            GameServiceContainer gsc = new GameServiceContainer();
            GraphicsAdapter ga = GraphicsAdapter.DefaultAdapter;
            GraphicsProfile gp = GraphicsProfile.HiDef;
            PresentationParameters pp = new PresentationParameters();
            pp.DeviceWindowHandle = this.Handle;
            pp.IsFullScreen = false;
            pp.BackBufferHeight = this.ClientSize.Height;
            pp.BackBufferWidth = this.ClientSize.Width;
            pp.BackBufferFormat = SurfaceFormat.Color;

            GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, gp, pp);

            
            gsc.AddService(typeof(IGraphicsDeviceService), new FakeGraphicsDeviceService(gd));
            ContentManager cm = new ContentManager(gsc, Directory.GetCurrentDirectory() + @"\Content");

            DirectoryInfo di = new DirectoryInfo(@"Content\Images");
            foreach (var fi in di.GetFiles("*.xnb"))
            {

                var image = cm.Load<Texture2D>("Images/" + fi.Name.Substring(0, fi.Name.Length - 4));
                if (image != null)
                {
                    using (var fs = new FileStream(String.Format(@"{0}\{1}.png", outputPath, fi.Name.Substring(0, fi.Name.Length - 4)), FileMode.Create, FileAccess.Write))
                    {
                        image.SaveAsPng(fs, image.Width, image.Height);
                    }
                }

            }

            cm.Dispose();

            MessageBox.Show("Stock texture pack created at: \n\n" + outputPath);
        }

        internal class FakeGraphicsDeviceService : IGraphicsDeviceService
        {
            private GraphicsDevice graphicsDevice;
            public FakeGraphicsDeviceService(GraphicsDevice dev)
            {
                graphicsDevice = dev;
            }

            public event EventHandler<EventArgs> DeviceCreated;
            public event EventHandler<EventArgs> DeviceDisposing;
            public event EventHandler<EventArgs> DeviceReset;
            public event EventHandler<EventArgs> DeviceResetting;

            public GraphicsDevice GraphicsDevice
            {
                get { return graphicsDevice; }
            }
        }

        #endregion

        private void refreshList_Click(object sender, EventArgs e)
        {
            PopulateTexturePacks();
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(((LinkLabel)sender).Tag.ToString());
        }

        public bool CreateCraftableList { get { return createCraftableList.Checked; } }
        public bool Lava { get { return lava.Checked; } }
        public bool Rain { get { return rain.Checked; } }
        public bool LavaCleanup { get { return lavaCleanup.Checked;  } }
        public int RainfallRate { get { return rainRate.Value; } }
        public bool WaterInHell { get { return waterInHell.Checked; } }
        public bool InfiniteGoblinInvasion { get { return infiniteGoblinInvasion.Checked; } }
        public bool InfiniteBloodMoon { get { return infiniteBloodMoon.Checked; } }
        public bool SpawnEye { get { return spawnEye.Checked; } }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                @"Due to a math calculation issue in Terraria.Main.InitTargets(), if your Eyefinity display is wider than 2,048 pixels, there is a likelihood that the game will crash when it tries to generate its render targets.

I can't currently fix the issue without redistributing Re-Logic's code, so the fix will have to wait.

Sorry, guys.", "Eyefinity Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lava_CheckedChanged(object sender, EventArgs e)
        {
            if (lava.Checked)
            {
                lava.Checked = MessageBox.Show(
                    @"You realize that this option causes liquid hot magma to pour from the skies and it doesn't evaporate, right?

This option is here solely for sadists and advanced players.

Are you absolutely sure you want to enable this option?", "Lava Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop
                    ) == System.Windows.Forms.DialogResult.Yes;
            }
        }
    }
}
