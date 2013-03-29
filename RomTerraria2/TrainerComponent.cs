using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RomTerraria.Properties;

namespace RomTerraria
{
    public class TrainerComponent : GameComponent
    {
        Settings settings = null; 
        private TimeSpan timeSinceLastBuff;

        public TrainerComponent(Game game) : base(game)
        {
            settings = new Settings();
            this.Enabled =
                settings.ManaBoots ||
                settings.RegenMana ||
                settings.RegenHealth;
        }

        public override void Update(GameTime gameTime)
        {
            if (Terraria.Main.netMode != 0) return; // No trainer in MP
            var p = Terraria.Main.player[Terraria.Main.myPlayer];

            if (settings.ManaBoots)
            {
                if (p != null && p.active && p.rocketBoots > 0)
                {
                    if (p.rocketTime < p.rocketTimeMax && p.statMana > 10)
                    {
                        p.statMana -= 3;
                        p.rocketTime = p.rocketTimeMax;
                    }
                }
            }

            timeSinceLastBuff += gameTime.ElapsedGameTime;

            if (timeSinceLastBuff < TimeSpan.FromMilliseconds(settings.RegenTimer)) return;
            timeSinceLastBuff = TimeSpan.Zero;

            if (p != null &&
                p.active)
            {
                if (p.statLife < p.statLifeMax && settings.RegenHealth)
                    p.statLife++;

                if (p.statMana < p.statManaMax && settings.RegenMana)
                    p.statMana++;
            }

            base.Update(gameTime);
        }
    }
}
