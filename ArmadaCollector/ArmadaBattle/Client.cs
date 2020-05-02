using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaCollector
{
    public static class Client
    {
        public static bool lostConnection;
        public static string username { get; set; }
        public static string password { get; set; }
        public static DateTime sessionStartTime { get; internal set; }
        public static bool running { get; internal set; }
        public static bool collecting { get; internal set; }

        public static int collectedGolds { get; internal set; }
        public static int collectedDiamonds { get; internal set; }
        public static int collectedExps { get; internal set; }
        public static int collectedElixirs { get; internal set; }
        public static int collectedGlows { get; internal set; }

        public static string playerExp { get; internal set; }
        public static bool ready { get; internal set; } = false;
    }
}