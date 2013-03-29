using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RomTerraria.Properties;
using Microsoft.Xna.Framework.Input;

namespace RomTerraria
{
    public class MapComponent : DrawableGameComponent
    {
        private int surroundingAreaWidth = 512;
        private int surroundingAreaHeight = 384;
        private Terraria.Main TerrariaGame = null;
        private Texture2D OverworldMap, OverworldMapNextTexture;
        private Texture2D SurroundingAreaMap, SurroundingAreaMapNextTexture;
        private int width, height;
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private TimeSpan updateTime = TimeSpan.Zero;
        private TimeSpan realtimeElapsedTime = TimeSpan.Zero;
        private TimeSpan realtimeUpdateTime = TimeSpan.Zero;
        private Color[] textureColors;
        private SpriteBatch spriteBatch;
        private bool textureColorsInitialized = false;
        private Color[] surroundingAreaTexture = null; // = new Color[surroundingAreaWidth * surroundingAreaHeight];

        //public bool ShowOverworld { get; set; }
        //public bool ShowRealtime { get; set; }

        Settings settings = null; // new Settings();

        private Dictionary<int, string> tileDescriptions = new Dictionary<int, string>();
        private void FillTileDescriptions()
        {
            tileDescriptions[0] = "Dirt";
            tileDescriptions[1] = "Stone";
            tileDescriptions[2] = "Topsoil";
            tileDescriptions[3] = "Grass";
            tileDescriptions[4] = "Torch";
            tileDescriptions[5] = "Wood";
            tileDescriptions[6] = "Iron";
            tileDescriptions[7] = "Copper";
            tileDescriptions[8] = "Gold";
            tileDescriptions[9] = "Silver";
            tileDescriptions[10] =
                tileDescriptions[11] = "Door";
            tileDescriptions[12] = "Heart";
            tileDescriptions[13] = "Vase";
            tileDescriptions[14] = "Table";
            tileDescriptions[15] = "Chair";
            tileDescriptions[16] = "Anvil";
            tileDescriptions[17] = "Furnace";
            tileDescriptions[18] = "Workbench";
            tileDescriptions[19] = "Platform";
            tileDescriptions[20] = "Sapling";
            tileDescriptions[21] = "Chest";
            tileDescriptions[22] =
            tileDescriptions[25] = "Corrupt Stone";
            tileDescriptions[23] = "Corruption";
            tileDescriptions[24] = "Corrupt Grass";
            tileDescriptions[26] = "Demon Altar";
            tileDescriptions[27] = "Sunflower";
            tileDescriptions[28] = "Breakable Vase";
            tileDescriptions[29] = "Piggy Bank";
            tileDescriptions[30] = "Wood Plank";
            tileDescriptions[31] = "Shadow Orb";
            tileDescriptions[32] = "Corrupt Vine";
            tileDescriptions[33] = "Candle";
            tileDescriptions[34] =
                tileDescriptions[35] =
                tileDescriptions[36] = "Chandelier";
            tileDescriptions[37] = "Ore";
            tileDescriptions[38] =
                tileDescriptions[39] =
                tileDescriptions[41] =
                tileDescriptions[43] =
                tileDescriptions[44] =
                tileDescriptions[45] =
                tileDescriptions[46] =
                tileDescriptions[47] =
                tileDescriptions[75] =
                tileDescriptions[76] = "Bricks";
            tileDescriptions[40] = "Mud";
            tileDescriptions[42] = "Dungeon Lamp";
            tileDescriptions[48] = "Spike";
            tileDescriptions[49] = "Water Candle";
            tileDescriptions[50] = "Books";
            tileDescriptions[51] = "Web";
            tileDescriptions[52] = "Vine";
            tileDescriptions[53] = "Sand";
            tileDescriptions[54] = "Glass";
            tileDescriptions[55] = "Sign";
            tileDescriptions[56] = "Ore";
            tileDescriptions[57] = "Corrupt Sand";
            tileDescriptions[58] = "Hellstone";
            tileDescriptions[59] = "Corrupt Mud";
            tileDescriptions[60] = "Jungle Topsoil";
            tileDescriptions[61] = "Jungle Grass";
            tileDescriptions[62] = "Jungle Vine";
            tileDescriptions[63] =
                tileDescriptions[64] =
                tileDescriptions[65] =
                tileDescriptions[66] =
                tileDescriptions[67] =
                tileDescriptions[68] = "Gemstone";
            tileDescriptions[69] = "Spiky Vine";
            tileDescriptions[70] = "Mushroom Soil";
            tileDescriptions[71] = "Mushrooms";
            tileDescriptions[73] =
                tileDescriptions[74] = "Flowers";
            tileDescriptions[77] = "Hellforge";
            tileDescriptions[78] = "Small Clay Pot";
        }
        private void InitializeTextureColors()
        {
            if (textureColorsInitialized) return;
            textureColorsInitialized = true;
            textureColors = new Color[Terraria.Main.tileTexture.Length];
            int texelCount = 0;
            for (int i = 0; i < Terraria.Main.tileTexture.Length; i++)
            {
                if (Terraria.Main.tileTexture[i] == null)
                {
                    textureColors[i] = Color.Transparent;
                }
                else
                {
                    Color[] retrievedColor = new Color[Terraria.Main.tileTexture[i].Width * Terraria.Main.tileTexture[i].Height];
                    Terraria.Main.tileTexture[i].GetData<Color>(0, 
                        new Rectangle(0, 0, Terraria.Main.tileTexture[i].Width, Terraria.Main.tileTexture[i].Height), 
                        retrievedColor, 0, Terraria.Main.tileTexture[i].Width * Terraria.Main.tileTexture[i].Height);
                    //Terraria.Main.tileTexture[i].GetData<Color>(0, new Rectangle(4, 4, 1, 1), retrievedColor, 0, 1);
                    Vector4 v = Vector4.Zero;
                    texelCount = 0;
                    for (int j = 0; j <= retrievedColor.GetUpperBound(0); j++)
                    {
                        // TODO: Finish making this a "significant color" extractor
                        var vecToAdd = retrievedColor[j].ToVector4();
                        v += vecToAdd;
                        texelCount++;
                    }
                    if (texelCount == 0)
                    {
                        textureColors[i] = Color.Black;
                    }
                    else
                    {
                        v = v / texelCount;
                        textureColors[i] = new Color(v); // retrievedColor[0];
                    }
                }
            }
        }


        public MapComponent(Game game)
            : base(game)
        {
            TerrariaGame = (Terraria.Main)game;

        }

        public override void Initialize()
        {
            Terraria.Main.maxScreenH = 8192;
            Terraria.Main.maxScreenW = 8192;
            base.Initialize();
            settings = new Settings();
            base.Enabled = base.Visible = settings.GlobalMinimap || settings.LocalMinimap || settings.LabelNPCRooms || settings.ShowTooltip;
            if (settings.ShowTooltip)
            {
                FillTileDescriptions();
            }
            //DrawOrder = 99999;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            //width = Terraria.Main.screenWidth;
            //height = Terraria.Main.screenHeight;
            surroundingAreaWidth = Terraria.Main.screenWidth / 2;
            surroundingAreaHeight = (int)(surroundingAreaWidth / ((float)Terraria.Main.screenWidth / (float)Terraria.Main.screenHeight));
            width = surroundingAreaWidth;
            height = surroundingAreaHeight;
            surroundingAreaTexture = new Color[surroundingAreaWidth * surroundingAreaHeight];
            OverworldMap = new Texture2D(TerrariaGame.GraphicsDevice, width, height);
            OverworldMapNextTexture = new Texture2D(TerrariaGame.GraphicsDevice, width, height);
            SurroundingAreaMap = new Texture2D(TerrariaGame.GraphicsDevice, surroundingAreaWidth, surroundingAreaHeight);
            SurroundingAreaMapNextTexture = new Texture2D(TerrariaGame.GraphicsDevice, surroundingAreaWidth, surroundingAreaHeight);
            textureColors = new Color[Terraria.Main.tileTexture.Length];
            spriteBatch = new SpriteBatch(TerrariaGame.GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            OverworldMap.Dispose();
            OverworldMap = null;
            base.UnloadContent();
        }

        public void Draw()
        {
            if (Terraria.Main.gameMenu ||
                Terraria.Main.hideUI ||
                Terraria.Main.chatMode) return; // If we're in the menu or chat is open, we shouldn't draw
            InitializeTextureColors(); // Has to happen in draw, otherwise the textures haven't necessarily been loaded yet

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            int mapHeight = (int)(height * ((float)Terraria.Main.maxTilesY / Terraria.Main.maxTilesX));

            if (settings.LabelNPCRooms)
            {
                for (int i = 0; i < Terraria.Main.npc.GetUpperBound(0); i++)
                {
                    var n = Terraria.Main.npc[i];
                    if (n != null && n.active && n.townNPC && !n.homeless)
                    {
                        float nx = (n.homeTileX * 16) - Terraria.Main.screenPosition.X;
                        float ny = ((n.homeTileY - 1) * 16) - Terraria.Main.screenPosition.Y;
                        spriteBatch.DrawString(Terraria.Main.fontItemStack, n.name, new Vector2(nx, ny), Color.FromNonPremultiplied(191, 191, 255, 191)); // Color.AliceBlue);
                    }
                }
            }

            if (settings.ShowTooltip && (Terraria.Main.keyState.IsKeyDown(Keys.LeftControl) || Terraria.Main.keyState.IsKeyDown(Keys.RightControl)))
            {
                Vector2 mouse = new Vector2(Terraria.Main.mouseState.X, Terraria.Main.mouseState.Y);
                var p = Terraria.Main.player[Terraria.Main.myPlayer];
                var tx = (int)(Terraria.Main.screenPosition.X + mouse.X) / 16;
                var ty = (int)(Terraria.Main.screenPosition.Y + mouse.Y) / 16;
                var t = Terraria.Main.tile[tx, ty];
                string s = Terraria.Main.tileName[t.type];
                if (String.IsNullOrWhiteSpace(s))
                {
                    if (tileDescriptions.TryGetValue(t.type, out s))
                    {
                        s = String.Format("{0} (#{1})", s, t.type);
                    }
                    else
                    {
                        s = String.Format("Unknown (#{0})", t.type);
                    }
                }
                if (t != null && t.active && !String.IsNullOrWhiteSpace(s))
                {
                    UIHelper.DrawShadowedText(spriteBatch,
                        Terraria.Main.fontMouseText,
                        s,
                        mouse,
                        Color.YellowGreen);
                }
            }

            float aspectRatio = (surroundingAreaHeight / (float)surroundingAreaWidth);

            Rectangle mapDestination = new Rectangle(Terraria.Main.screenWidth / 4, Terraria.Main.screenHeight - (Terraria.Main.screenHeight / 5), Terraria.Main.screenWidth / 2, (Terraria.Main.screenHeight / 5));
                //new Rectangle(Terraria.Main.screenWidth / 4, Terraria.Main.screenHeight - (int)(mapHeight / aspectRatio), Terraria.Main.screenWidth / 2, (int)(mapHeight / aspectRatio));
                //new Rectangle((Terraria.Main.screenWidth / 2) - (width / 2), Terraria.Main.screenHeight - mapHeight, width, mapHeight);
 
            Rectangle areaMapSource = new Rectangle(0, (int)((surroundingAreaHeight / 2) - (surroundingAreaHeight * aspectRatio / 2)), surroundingAreaWidth, (int)(surroundingAreaHeight * aspectRatio));
            if (Terraria.Main.playerInventory)
            { // Only going to draw full map if inventory is up
                if (settings.GlobalMinimap)
                {
                    spriteBatch.Draw(Terraria.Main.fadeTexture, mapDestination, Color.FromNonPremultiplied(0, 0, 0, 224));
                    var p = Terraria.Main.player[Terraria.Main.myPlayer];
                    spriteBatch.Draw(OverworldMap, mapDestination, Color.White);
                    if (p != null && p.active)
                    {
                        int x = (int)((p.position.X + (p.width * 0.5)) / 16.0) / (int)((float)Terraria.Main.maxTilesX / width);
                        int y = (int)((p.position.Y + (p.height * 0.5)) / 16.0) / (int)((float)Terraria.Main.maxTilesY / mapHeight);
                        Rectangle playerLoc = new Rectangle((width / 2) + x, (Terraria.Main.screenHeight - mapHeight) + y, 12, 12);
                        spriteBatch.Draw(Terraria.Main.cursorTexture, playerLoc, Terraria.Main.cursorColor);
                    }
                }
            }
            else
            {
                if (settings.LocalMinimap)
                {
                    spriteBatch.Draw(Terraria.Main.fadeTexture, mapDestination, Color.FromNonPremultiplied(0, 0, 0, 224));
                    // Draw surrounding area map
                    //spriteBatch.Draw(SurroundingAreaMap, new Rectangle(width / 2, Terraria.Main.screenHeight - mapHeight, width, mapHeight), Color.White);

                    spriteBatch.Draw(SurroundingAreaMap, mapDestination, areaMapSource, 
                        Color.White); // new Rectangle(0, surroundingAreaHeight / 4, surroundingAreaWidth, surroundingAreaHeight / 2), Color.White);
                }
            }
            spriteBatch.End();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedTime += gameTime.ElapsedGameTime;
            realtimeElapsedTime += gameTime.ElapsedGameTime;
            if (Terraria.Main.gameMenu) return; // If we're in the menu, we shouldn't update
            if (!textureColorsInitialized) return; // Nothing to draw yet to texture

            // Working on a real-time smaller map section
            if (settings.LocalMinimap && realtimeUpdateTime < realtimeElapsedTime)
            {
                realtimeUpdateTime = TimeSpan.FromMilliseconds(500);
                realtimeElapsedTime = TimeSpan.Zero;

                var p = Terraria.Main.player[Terraria.Main.myPlayer];
                int mapHeight = (int)(height * ((float)Terraria.Main.maxTilesY / Terraria.Main.maxTilesX));

                int px = (int)(p.position.X / 16.0);
                int py = (int)(p.position.Y / 16.0);

                int left = Math.Max(px - surroundingAreaWidth / 2, 0);
                int top = Math.Max(py - surroundingAreaHeight / 2, 0);
                for (int i = 0; i < surroundingAreaTexture.GetUpperBound(0); i++)
                    surroundingAreaTexture[i] = Color.Transparent;
                for (int y = top, yofs = 0; yofs < surroundingAreaHeight && y < Terraria.Main.maxTilesY; y++, yofs++)
                {
                    for (int x = left, xofs = 0; xofs < surroundingAreaWidth && x < Terraria.Main.maxTilesX; x++, xofs++)
                    {
                        float lightLevel = 0.5f; // 0.25f + (Terraria.Lighting.Brightness(w, h) * 0.75f);
                        if (x < 0 || y < 0)
                        {
                            surroundingAreaTexture[xofs + (yofs * surroundingAreaWidth)] = Color.Transparent;
                        }
                        else
                        {
                            Terraria.Tile t = Terraria.Main.tile[x, y];
                            surroundingAreaTexture[xofs + (yofs * surroundingAreaWidth)] = (t != null) ?
                                (t.lava ? Color.Red : t.liquid > 0 ? Color.Blue : t.active ?
                                    Color.FromNonPremultiplied(
                                        new Vector4(textureColors[t.type].R * lightLevel / 256,
                                                    textureColors[t.type].G * lightLevel / 256,
                                                    textureColors[t.type].B * lightLevel / 256, 1.0f))
                                    : Color.Transparent) :
                                Color.Transparent;
                        }
                    }
                }


                surroundingAreaTexture[surroundingAreaWidth * (py - top) + (px - left)] = Color.Magenta;
                try
                {
                    SurroundingAreaMapNextTexture.SetData<Color>(surroundingAreaTexture, 0, surroundingAreaWidth * surroundingAreaHeight);
                    Texture2D temp2 = SurroundingAreaMap;
                    SurroundingAreaMap = SurroundingAreaMapNextTexture;
                    SurroundingAreaMapNextTexture = temp2;
                }
                catch (InvalidOperationException)
                { } // Ignore...means FPS is too low
            }

            if (settings.GlobalMinimap && updateTime < elapsedTime)
            {
                updateTime = TimeSpan.FromMinutes(1); //Terraria.Main.netMode == 0 ? 5 : 1); // Update every five minutes in single player, one in multiplayer
                elapsedTime = TimeSpan.Zero;

                int worldwidth = Terraria.Main.maxTilesX;
                int worldheight = Terraria.Main.maxTilesY;
                int widthstep = (int)((float)worldwidth / width);
                int heightstep = (int)((float)worldheight / height);
                Color[] newTexture = new Color[width * height];
                for (int i = 0; i < newTexture.GetUpperBound(0); i++)
                    newTexture[i] = Color.Transparent;
                for (int h = 0, hofs = 0; h < worldheight && hofs < height; h += heightstep, hofs++)
                {
                    for (int w = 0, wofs = 0; w < worldwidth && wofs < width; w += widthstep, wofs++)
                    {
                        // Terraria.Lighting.Brightness is calculated only for the current screen.  D'oh.
                        float lightLevel = 0.5f; // 0.25f + (Terraria.Lighting.Brightness(w, h) * 0.75f);
                        Terraria.Tile t = Terraria.Main.tile[w, h];
                        newTexture[wofs + (hofs * width)] = (t != null) ?
                            (t.lava ? Color.Red : t.liquid > 0 ? Color.Blue : t.active ?
                                Color.FromNonPremultiplied(
                                    new Vector4(textureColors[t.type].R * lightLevel / 256,
                                                textureColors[t.type].G * lightLevel / 256,
                                                textureColors[t.type].B * lightLevel / 256, 1.0f))
                                : Color.Transparent) :
                            Color.Transparent;
                    }
                }
                try
                {
                    OverworldMapNextTexture.SetData<Color>(newTexture, 0, width * height);
                    Texture2D temp = OverworldMap;
                    OverworldMap = OverworldMapNextTexture;
                    OverworldMapNextTexture = temp;
                }
                catch (InvalidOperationException) { } // Ignore...means FPS is too low
                // Was only using this to test the overlay creation piece.  You will quickly get an exception if you enable this.
                //using (var fs = new System.IO.FileStream("overlay.jpg", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                //{
                //    Overlay.SaveAsJpeg(fs, width, height);
                //}
            }
        }
    }
}
