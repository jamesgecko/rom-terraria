using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomTerraria
{
    // We pass in the GameSettings class into GameLauncher to make things go a lot easier
    public static class GameSettings
    {
        public static string Path { get; set; }

        public static bool CreateCraftableList { get; set; }

        // WorldComponent
        public static bool Rain { get; set; }
        public static int RainfallRate { get; set; }

        public static bool Lava { get; set; }
        public static int LavafallRate { get; set; }

        public static bool LavaCleanup { get; set; }

        public static bool WaterInHell { get; set; }

        public static bool InfiniteBloodMoon { get; set; }
        public static bool InfiniteGoblinInvasion { get; set; }
        public static bool SpawnEye { get; set; }


    }
}
