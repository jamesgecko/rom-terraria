using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Reflection;
using RomTerraria.Properties;
using System.IO;

namespace RomTerraria
{
    public class WorldComponent : GameComponent
    {
        TimeSpan elapsedTime = TimeSpan.Zero;
        Random random = new Random();
        TimeSpan tick = TimeSpan.FromMilliseconds(100);
        const int topOfWorld = 5;

        List<string> BadWords = null;

        Assembly terrariaAssembly;
        Type worldGen;
        Type main;
        FieldInfo shadowOrbSmashed;
        FieldInfo invasionSize;
        FieldInfo bloodMoon;
        FieldInfo time;
        FieldInfo spawnEye;
        MethodInfo startInvasion;

        bool lavaCleaned = false;
        bool eyeSpawnedToday = false;
        Settings settings = null;
        public WorldComponent(Game game)
            : base(game)
        {
            settings = new Settings();

            this.Enabled =
                GameSettings.Lava ||
                GameSettings.Rain ||
                GameSettings.WaterInHell ||
                GameSettings.InfiniteBloodMoon ||
                GameSettings.InfiniteGoblinInvasion ||
                GameSettings.SpawnEye ||
                GameSettings.LavaCleanup ||
                settings.ProfanityFilter;

            if (settings.ProfanityFilter)
            {
                using (var str = new StringReader(Resources.badwords))
                {
                    BadWords = new List<string>();

                    while (str.Peek() >= 0)
                    {
                        BadWords.Add(str.ReadLine().Trim('*', ' ').ToLowerInvariant());
                    }
                }

            }

            terrariaAssembly = Assembly.GetAssembly(typeof(Terraria.Main));
            main = terrariaAssembly.GetType("Terraria.Main");
            worldGen = terrariaAssembly.GetType("Terraria.WorldGen");

            foreach (var f in worldGen.GetFields())
            {
                if (f.Name == "shadowOrbSmashed")
                {
                    shadowOrbSmashed = f;
                }
                if (f.Name == "spawnEye")
                {
                    spawnEye = f;
                }
            }

            foreach (var f in main.GetMethods(BindingFlags.Static | BindingFlags.NonPublic))
            {
                if (f.Name == "StartInvasion")
                {
                    startInvasion = f;
                }
            }

            foreach (var f in main.GetFields())
            {
                if (f.Name == "bloodMoon")
                {
                    bloodMoon = f;
                }
                if (f.Name == "invasionSize")
                {
                    invasionSize = f;
                }
                if (f.Name == "time")
                {
                    time = f;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (settings.ProfanityFilter && BadWords != null)
            {
                foreach (var cl in Terraria.Main.chatLine)
                {
                    if (cl != null && cl.showTime > 0 && !cl.text.StartsWith("~"))
                    {
                        StringBuilder sb = new StringBuilder(cl.text);

                        foreach (var s in BadWords)
                            sb.Replace(s, "**");
                        if (sb.Length < cl.text.Length + 1)
                            cl.text = "~" + sb.ToString();
                        else
                            cl.text = "~" + sb.ToString();
                    }
                }
            }

            if (Terraria.Main.netMode != 0)
            {
                lavaCleaned = false;
                return; // Only update if we're in single player
            }

            if (GameSettings.InfiniteGoblinInvasion && shadowOrbSmashed != null && startInvasion != null) // Some defensive coding
            {
                Terraria.Main.invasionDelay = 0;
                bool wasOrbSmashed = (bool)shadowOrbSmashed.GetValue(null);
                shadowOrbSmashed.SetValue(null, true);
                startInvasion.Invoke(null, null);
                shadowOrbSmashed.SetValue(null, wasOrbSmashed);
            }

            if (GameSettings.InfiniteBloodMoon && bloodMoon != null)
            {
                bloodMoon.SetValue(null, true);
            }

            if (GameSettings.SpawnEye && !Terraria.Main.gameMenu && spawnEye != null && time != null) // Per fb@malrix.net
            {
                if (!eyeSpawnedToday)
                {
                    spawnEye.SetValue(null, true);
                    eyeSpawnedToday = true;
                }
                else
                {
                    if ((double)time.GetValue(null) > 32400.0)
                    {
                        eyeSpawnedToday = false;
                    }
                }
            }

            if (GameSettings.WaterInHell)
            {
                for (int i = 0; i < Terraria.Main.liquid.GetUpperBound(0); i++)
                {
                    if (Terraria.Main.liquid[i] != null)
                    {
                        var t = Terraria.Main.tile[Terraria.Main.liquid[i].x, Terraria.Main.liquid[i].y];
                        if (t != null && t.liquid > 0 && !t.lava &&
                            Terraria.Main.liquid[i].y > Terraria.Main.maxTilesY - 220)
                        {
                            t.liquid = 192;
                        }
                    }
                }
            }


            int y = topOfWorld;
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime < tick) return;
            elapsedTime -= tick;
            if (GameSettings.Rain && !Terraria.Main.gameMenu)
            {

                for (int x = (int)(Terraria.Main.screenPosition.X / 16) - 100;
                    x < (Terraria.Main.screenPosition.X / 16) + (Terraria.Main.screenWidth / 16) + 100;
                    x++)
                {
                    if (x >= 0 && x <= Terraria.Main.maxTilesX && random.Next(200) == 0)
                    {
                        if (Terraria.Main.tile[x, y] == null)
                            Terraria.Main.tile[x, y] = new Terraria.Tile();
                        Terraria.Main.tile[x, y].liquid = (byte)Math.Min(random.Next(GameSettings.RainfallRate), 255);
                        Terraria.Liquid.AddWater(x, y);
                    }
                }
            }


            if (GameSettings.Lava && !Terraria.Main.gameMenu)
            {


                for (int x = (int)(Terraria.Main.screenPosition.X / 16) - 100;
                    x < (Terraria.Main.screenPosition.X / 16) + (Terraria.Main.screenWidth / 16) + 100;
                    x++)
                {
                    if (x >= 0 && x <= Terraria.Main.maxTilesX && random.Next(200) == 0)
                    {
                        if (Terraria.Main.tile[x, y] == null)
                            Terraria.Main.tile[x, y] = new Terraria.Tile();
                        Terraria.Main.tile[x, y].liquid = (byte)random.Next(8);
                        Terraria.Main.tile[x, y].lava = true;
                        Terraria.Liquid.AddWater(x, y);

                    }
                }
            }


            if (GameSettings.LavaCleanup && !lavaCleaned)
            {
                lavaCleaned = true;
                for (int yl = 0; yl < Terraria.Main.maxTilesY / 4; yl++) 
                {
                    for (int x = 0; x < Terraria.Main.maxTilesX; x++)
                    {
                        var t = Terraria.Main.tile[x, yl];
                        if (t != null && t.lava && t.liquid > 0)
                        {
                            t.liquid = 0;
                            t.lava = false;
                        }
                    }
                }

                Terraria.Liquid.UpdateLiquid();


                for (int i = 0; i < Terraria.Main.liquid.GetUpperBound(0); i++)
                {
                    if (Terraria.Main.liquid[i] != null)
                    {
                        var t = Terraria.Main.tile[Terraria.Main.liquid[i].x, Terraria.Main.liquid[i].y];
                        if (t != null && t.liquid > 0 && t.lava &&
                            Terraria.Main.liquid[i].y < Terraria.Main.maxTilesY / 4)
                        {
                            Terraria.Liquid.DelWater(i);
                        }
                    }
                }


                Terraria.Liquid.UpdateLiquid();
            }
        }
    }
}
