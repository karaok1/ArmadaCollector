using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaCollector
{
    public static class Client
    {
        public static string scriptCode { get; set; }
        public static bool lostConnection;

        public static string username { get; set; }
        public static string password { get; set; }
        public static DateTime sessionStartTime { get; set; }
        public static bool running { get; set; }
        public static bool collecting { get; set; }
        public static bool manuelStart { get; set; } = false;

        public static int collectedGolds { get; set; }
        public static int collectedDiamonds { get; set; }
        public static int collectedExps { get; set; }
        public static int collectedElixirs { get; set; }
        public static int collectedGlows { get; set; }
        public static int gainedDiamond { get; set; }
        public static int gainedGold { get; set; }
        public static int gainedElixir { get; set; }
        public static string playerExp { get; set; }
        public static bool ready { get; set; } = false;
    }
}