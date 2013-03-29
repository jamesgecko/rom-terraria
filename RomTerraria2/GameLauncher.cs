using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Microsoft.Xna.Framework;
using RomTerraria.Properties;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Xna.Framework.Content;
using System.Reflection;

namespace RomTerraria
{
    public class GameLauncher : Terraria.Main
    {
        Settings settings = new Settings();

        MapComponent mapComponent = null;

        SpriteBatch spriteBatch = null;

        protected override void Initialize()
        {
            Content.RootDirectory = GameSettings.Path + @"\Content";

            // from jra101@gmail.com
            System.Windows.Forms.Form mainForm = 
                (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(base.Window.Handle);

            var terrariaAssembly = Assembly.GetAssembly(typeof(Terraria.Main));
            Type gameType = terrariaAssembly.GetType("Terraria.Main");
            var TerrariaGame = (Terraria.Main)this;

            FieldInfo numModes = gameType.GetField("numDisplayModes", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo modeWidths = gameType.GetField("displayWidth", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo modeHeights = gameType.GetField("displayHeight", BindingFlags.NonPublic | BindingFlags.Instance);

            if (numModes == null) throw new MissingFieldException("numModes");
            if (modeWidths == null) throw new MissingFieldException("displayWidth");
            if (modeHeights == null) throw new MissingFieldException("displayHeight");

            if (settings.UseHiDef)
            {
                var gdm = Services.GetService(typeof(IGraphicsDeviceManager)) as GraphicsDeviceManager;
                if (gdm != null)
                {
                    gdm.GraphicsProfile = GraphicsProfile.HiDef;
                }
            }


            Components.Add(new TrainerComponent(this));
            Components.Add(new WorldComponent(this));
            mapComponent = new MapComponent(this);
            Components.Add(mapComponent);

            base.Initialize();

            if (settings.GameResizeMode == 1)
            {
                Terraria.Main.screenHeight =
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                Terraria.Main.screenWidth =
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                base.toggleFullscreen = false;
            }
            else if (settings.GameResizeMode == 2)
            {
                #region Non-standard resolutions
                Terraria.Main.screenHeight = settings.GameHeight;
                Terraria.Main.screenWidth = settings.GameWidth;

                Terraria.Main.maxScreenH = (int)Math.Max(Terraria.Main.maxScreenH, Terraria.Main.screenHeight);
                Terraria.Main.maxScreenW = (int)Math.Max(Terraria.Main.maxScreenW, Terraria.Main.screenWidth);


                bool found = false;
                for (int i = 0; i < (int)numModes.GetValue(TerrariaGame); i++)
                {
                    if (((int[])modeWidths.GetValue(TerrariaGame))[i] == Terraria.Main.screenWidth &&
                        ((int[])modeHeights.GetValue(TerrariaGame))[i] == Terraria.Main.screenHeight)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    List<int> w = ((int[])modeWidths.GetValue(TerrariaGame)).ToList();
                    List<int> h = ((int[])modeHeights.GetValue(TerrariaGame)).ToList();
                    w.Add(Terraria.Main.screenWidth);
                    h.Add(Terraria.Main.screenHeight);
                    numModes.SetValue(TerrariaGame, ((int)numModes.GetValue(TerrariaGame)) + 1);
                    modeWidths.SetValue(TerrariaGame, w.ToArray());
                    modeHeights.SetValue(TerrariaGame, h.ToArray());
                }
                #endregion
            }

            // Oversetting the resolutions can cause a ton of zeros to end up in the resolution list
            // This section of code cleans it up
            List<int> finalwidths = ((int[])modeWidths.GetValue(TerrariaGame)).ToList();
            List<int> finalheights = ((int[])modeHeights.GetValue(TerrariaGame)).ToList();

            finalwidths.RemoveAll(i => i == 0);
            finalheights.RemoveAll(i => i == 0);
            modeWidths.SetValue(TerrariaGame, finalwidths.ToArray());
            modeHeights.SetValue(TerrariaGame, finalheights.ToArray());
            numModes.SetValue(TerrariaGame, finalwidths.Count);

            if (settings.GameResizeMode == 1)
            {
                mainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                mainForm.Location = new System.Drawing.Point(0, 0);
                mainForm.TopLevel = true;
            }

            mainForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon("Terraria.exe");

            if (GameSettings.CreateCraftableList) CreateCraftableList();

        }

        #region Craftable List
        
        private void CreateCraftableList()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Terraria Craftables List for ");
            sb.AppendLine(Terraria.Main.versionNumber);
            sb.AppendLine("Created by RomTerraria - http://www.romsteady.net");
            sb.AppendLine("-------------------------------------------------");
            var recipes = Terraria.Main.recipe;
            foreach (var r in recipes)
            {
                if (r != null && !String.IsNullOrWhiteSpace(r.createItem.name))
                {
                    string s = r.createItem.name + ":";
                    foreach (var i in r.requiredItem)
                    {
                        if (i != null && i.stack > 0)
                        {
                            s += String.Format(" {0} ({1}),", i.name, i.stack);
                        }
                    }
                    if (r.requiredTile[0] >= 0)
                    {
                        string tile = r.requiredTile[0].ToString();
                        switch (r.requiredTile[0])
                        {
                            case 13: tile = "Alchemy Station"; break;
                            case 14: tile = "Table"; break;
                            case 16: tile = "Anvil"; break;
                            case 17: tile = "Furnace"; break;
                            case 18: tile = "Workbench"; break;
                            case 26: tile = "Demon Altar"; break;
                            case 77: tile = "Hellforge"; break;
                            default: tile = "#" + r.requiredTile[0].ToString(); break;
                        }
                        s += String.Format(" required to be by {0}", tile);
                    }
                    sb.AppendLine(s.TrimEnd(','));
                }
            }

            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\TerrariaCraftables.txt"))
            {
                sw.Write(sb.ToString());
            }
        }
        #endregion
        #region Texture Pack

        ContentManager texturePackContent = null;

        private SpriteFont LoadFont(string file)
        {
            try
            {
                return texturePackContent.Load<SpriteFont>(file);
            }
            catch
            {
                return null;
            }
        }

        private Texture2D LoadTexture(string file, string path, bool isZip)
        {
            if (isZip)
            {
                using (var zf = new ZipFile(path))
                {
                    var entry = zf.GetEntry(file + ".png");
                    if (entry != null)
                    {
                       using (var zs = zf.GetInputStream(entry))
                       {
                           using (var ms = new MemoryStream())
                           {
                               zs.CopyTo(ms);
                               ms.Position = 0;
                               return Texture2D.FromStream(GraphicsDevice, ms);
                           }                           
                       }
                    }
                }
            }
            else
            {
                string final = String.Format("{0}/{1}.png", path, file);
                if (File.Exists(final))
                {
                    using (FileStream fs = new FileStream(final, FileMode.Open, FileAccess.Read))
                    {
                        return Texture2D.FromStream(GraphicsDevice, fs);
                    }
                }
            }
            return null;
        }

        private void LoadTextureSet(Texture2D[] set, string fileMask, string path, bool isZip)
        {
            
            for (int i = 0; i <= set.GetUpperBound(0); i++)
            {
                set[i] = LoadTexture(String.Format(fileMask, i), path, isZip) ?? set[i];
            }
        }

        private void LoadTexturePack(string path, bool isZip)
        {
            Texture2D temp;
            LoadTextureSet(tileTexture, "Images/Tiles_{0}", path, isZip);
            LoadTextureSet(wallTexture, "Images/Wall_{0}", path, isZip);
            LoadTextureSet(buffTexture, "Images/Buff_{0}", path, isZip);
            LoadTextureSet(itemTexture, "Images/Item_{0}", path, isZip);
            LoadTextureSet(npcTexture, "Images/NPC_{0}", path, isZip);
            LoadTextureSet(projectileTexture, "Images/Projectile_{0}", path, isZip);
            LoadTextureSet(goreTexture, "Images/Gore_{0}", path, isZip);
            LoadTextureSet(cloudTexture, "Images/Cloud_{0}", path, isZip);
            LoadTextureSet(starTexture, "Images/Star_{0}", path, isZip);
            LoadTextureSet(liquidTexture, "Images/Liquid_{0}", path, isZip);
            LoadTextureSet(armorArmTexture, "Images/Armor_Body_{0}", path, isZip);
            LoadTextureSet(armorBodyTexture, "Images/Armor_Arm_{0}", path, isZip);
            LoadTextureSet(armorHeadTexture, "Images/Armor_Head_{0}", path, isZip);
            LoadTextureSet(armorLegTexture, "Images/Armor_Legs_{0}", path, isZip);
            LoadTextureSet(playerHairTexture, "Images/Player_Hair_{0}", path, isZip);
            LoadTextureSet(treeTopTexture, "Images/Tree_Tops_{0}", path, isZip);
            LoadTextureSet(treeBranchTexture, "Images/Tree_Brances_{0}", path, isZip);

            for (int i = 0; i <= Terraria.Main.backgroundTexture.GetUpperBound(0); i++)
            {
                temp = LoadTexture(String.Format("Images/Background_{0}", i), path, isZip);
                if (temp != null)
                {
                    Terraria.Main.backgroundTexture[i] = temp;
                    Terraria.Main.backgroundWidth[i] = temp.Width;
                    Terraria.Main.backgroundHeight[i] = temp.Height;
                }
            }

            raTexture = LoadTexture("Images/ra-logo", path, isZip) ?? Terraria.Main.raTexture;
            reTexture = LoadTexture("Images/re-logo", path, isZip) ?? Terraria.Main.reTexture;
            splashTexture = LoadTexture("Images/splash", path, isZip) ?? Terraria.Main.splashTexture;
            fadeTexture = LoadTexture("Images/fade-out", path, isZip) ?? Terraria.Main.fadeTexture;
            cdTexture = LoadTexture("Images/CoolDown", path, isZip) ?? Terraria.Main.cdTexture;
            logoTexture = LoadTexture("Images/Logo", path, isZip) ?? Terraria.Main.logoTexture;
            dustTexture = LoadTexture("Images/Dust", path, isZip) ?? Terraria.Main.dustTexture;
            sunTexture = LoadTexture("Images/Sun", path, isZip) ?? Terraria.Main.sunTexture;
            sun2Texture = LoadTexture("Images/Sun2", path, isZip) ?? Terraria.Main.sun2Texture;
            moonTexture = LoadTexture("Images/Moon", path, isZip) ??  Terraria.Main.moonTexture;
            blackTileTexture = LoadTexture("Images/Black_Tile", path, isZip) ?? Terraria.Main.blackTileTexture;
            heartTexture = LoadTexture("Images/Heart", path, isZip) ?? Terraria.Main.heartTexture;
            bubbleTexture = LoadTexture("Images/Bubble", path, isZip) ?? Terraria.Main.bubbleTexture;
            manaTexture = LoadTexture("Images/Mana", path, isZip) ?? Terraria.Main.manaTexture;
            cursorTexture = LoadTexture("Images/Cursor", path, isZip) ?? Terraria.Main.cursorTexture;
            ninjaTexture = LoadTexture("Images/Ninja", path, isZip) ?? Terraria.Main.ninjaTexture;
            antLionTexture = LoadTexture("Images/AntlionBody", path, isZip) ?? Terraria.Main.antLionTexture;
            shroomCapTexture = LoadTexture("Images/Shroom_Tops", path, isZip) ?? Terraria.Main.shroomCapTexture;
            inventoryBackTexture = LoadTexture("Images/Inventory_Back", path, isZip) ?? Terraria.Main.inventoryBackTexture;
            textBackTexture = LoadTexture("Images/Text_Back", path, isZip) ?? Terraria.Main.textBackTexture;
            chatTexture = LoadTexture("Images/Chat", path, isZip) ?? Terraria.Main.chatTexture;
            chat2Texture = LoadTexture("Images/Chat2", path, isZip) ?? Terraria.Main.chat2Texture;
            chatBackTexture = LoadTexture("Images/Chat_Back", path, isZip) ?? Terraria.Main.chatBackTexture;
            teamTexture = LoadTexture("Images/Team", path, isZip) ?? Terraria.Main.teamTexture;
            playerEyeWhitesTexture = LoadTexture("Images/Player_Eye_Whites", path, isZip) ?? playerEyeWhitesTexture;
            playerEyesTexture = LoadTexture("Images/Player_Eyes", path, isZip) ?? playerEyesTexture;
            playerHandsTexture = LoadTexture("Images/Player_Hands", path, isZip) ?? playerHandsTexture;
            playerHands2Texture = LoadTexture("Images/Player_Hands2", path, isZip) ?? playerHands2Texture;
            playerHeadTexture = LoadTexture("Images/Player_Head", path, isZip) ?? playerHeadTexture;
            playerPantsTexture = LoadTexture("Images/Player_Pants", path, isZip) ?? playerPantsTexture;
            playerShirtTexture = LoadTexture("Images/Player_Shirt", path, isZip) ?? playerShirtTexture;
            playerShoesTexture = LoadTexture("Images/Player_Shoes", path, isZip) ?? playerShoesTexture;
            playerUnderShirtTexture = LoadTexture("Images/Player_Undershirt", path, isZip) ?? playerUnderShirtTexture;
            playerUnderShirt2Texture = LoadTexture("Images/Player_Undershirt2", path, isZip) ?? playerUnderShirt2Texture;
            chainTexture = LoadTexture("Images/Chain", path, isZip) ?? chainTexture;
            chain2Texture = LoadTexture("Images/Chain2", path, isZip) ?? chain2Texture;
            chain3Texture = LoadTexture("Images/Chain3", path, isZip) ?? chain3Texture;
            chain4Texture = LoadTexture("Images/Chain4", path, isZip) ?? chain4Texture;
            chain5Texture = LoadTexture("Images/Chain5", path, isZip) ?? chain5Texture;
            chain6Texture = LoadTexture("Images/Chain6", path, isZip) ?? chain6Texture;
            boneArmTexture = LoadTexture("Images/Arm_Bone", path, isZip) ?? boneArmTexture;

            if (isZip)
            {
                texturePackContent = new ZipContentManager(this.Services, path);
                
            }
            else
            {
                texturePackContent = new ContentManager(this.Services, path);
            }

            fontItemStack = LoadFont("Fonts/Item_Stack") ?? fontItemStack;
            fontMouseText = LoadFont("Fonts/Mouse_Text") ?? fontMouseText;
            fontDeathText = LoadFont("Fonts/Death_Text") ?? fontDeathText;
            fontCombatText[0] = LoadFont("Fonts/Combat_Text") ?? fontCombatText[0];
            fontCombatText[1] = LoadFont("Fonts/Combat_Crit") ?? fontCombatText[1];
        }
        #endregion

        private Texture2D ReduceResolution(Texture2D source)
        {
            Texture2D newTexture = new Texture2D(this.GraphicsDevice, source.Width / 2, source.Height / 2, false, source.Format);

            Color[] oldData = new Color[source.Width * source.Height];
            Color[] newData = new Color[(source.Width / 2) * (source.Height / 2)];
            source.GetData<Color>(oldData);
            int ofs = 0;
            for (int y = 0; y < source.Height; y += 2)
            {
                for (int x = 0; x < source.Width; x += 2)
                {
                    newData[ofs] = oldData[(y * source.Width) + x];
                    ofs++;
                }
            }

            newTexture.SetData(newData);
            return newTexture;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            // Texture pack stuff
            if (settings.UseTexturePacks)
            {
                if (File.Exists(settings.LastTexturePack))
                { // ZIP file
                    LoadTexturePack(settings.LastTexturePack, true);
                }
                else if (Directory.Exists(settings.LastTexturePack))
                { // Loose files
                    LoadTexturePack(settings.LastTexturePack, false);
                }
            }

            if (settings.UseInternalFonts)
            {
                RomTerraria.Properties.Resources.ResourceManager.IgnoreCase = true;
                var embeddedContent = new ResourceContentManager(this.Services, RomTerraria.Properties.Resources.ResourceManager);
                fontDeathText = embeddedContent.Load<SpriteFont>("Death_Text");
                fontItemStack = embeddedContent.Load<SpriteFont>("Item_Stack");
                fontMouseText = embeddedContent.Load<SpriteFont>("Mouse_Text");
                fontCombatText[0] = embeddedContent.Load<SpriteFont>("Combat_Text");
                fontCombatText[1] = embeddedContent.Load<SpriteFont>("Combat_Crit");
            }

            if (settings.ResizeBackgrounds)
            {
                for (int i = 0; i <= Terraria.Main.backgroundTexture.GetUpperBound(0); i++)
                {
                    //Terraria.Main.backgroundTexture[i] = ReduceResolution(Terraria.Main.backgroundTexture[i]);
                    //Terraria.Main.backgroundWidth[i] = Terraria.Main.backgroundTexture[i].Width * 2;
                    //Terraria.Main.backgroundHeight[i] = Terraria.Main.backgroundTexture[i].Height * 2;
                }
            }            

            spriteBatch = new SpriteBatch(this.GraphicsDevice);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            // My stuff
            if (mapComponent.Visible)
            {
                mapComponent.Draw();
            }

            spriteBatch.Begin();

            if (settings.InGameClock)
            {
                string time = DateTime.Now.ToShortTimeString();
                var size = fontItemStack.MeasureString(time);
                var pos = new Vector2(screenWidth - size.X, screenHeight - size.Y);
                UIHelper.DrawShadowedText(spriteBatch, fontItemStack, time, pos, Color.White);
            }

            spriteBatch.End();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // My stuff
        }
    }
}
