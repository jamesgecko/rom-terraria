using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RomTerraria
{
    public static class UIHelper
    {
        private static Vector2[] shadowOffset = { new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1) };
        private static Color shadowColor = Color.FromNonPremultiplied(0, 0, 0, 63);
        public static void DrawShadowedText(SpriteBatch sb, SpriteFont sf, string s, Vector2 v, Color c)
        {
            // Manually unrolling for performance
            sb.DrawString(sf, s, v + shadowOffset[0], shadowColor);
            sb.DrawString(sf, s, v + shadowOffset[1], shadowColor);
            sb.DrawString(sf, s, v + shadowOffset[2], shadowColor);
            sb.DrawString(sf, s, v + shadowOffset[3], shadowColor);
            sb.DrawString(sf, s, v, c);
        }

        public static void DrawShadowedText(SpriteBatch sb, SpriteFont sf, StringBuilder s, Vector2 v, Color c)
        {
            // Manually unrolling for performance
            sb.DrawString(sf, s, v + shadowOffset[0], shadowColor);
            sb.DrawString(sf, s, v + shadowOffset[1], shadowColor);
            sb.DrawString(sf, s, v + shadowOffset[2], shadowColor);
            sb.DrawString(sf, s, v + shadowOffset[3], shadowColor);
            sb.DrawString(sf, s, v, c);
        }
    }
}
