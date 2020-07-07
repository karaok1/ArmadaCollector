using ArmadaCollector.ArmadaBattle;
using ArmadaCollector.Utils;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmadaCollector
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            fingerprint = FingerPrint.Value();
            Initialize();
        }

        public static async void Initialize()
        {
            //AppUpdater.CheckForUpdates();
            Application.Run(new Form1());
        }

        public static string fingerprint = "";
    }
}
