using ArmadaCollector.Proxy;
using Fiddler;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CertMaker.createRootCert();
            CertMaker.trustRootCert();
            StartBrowserProxy();
            Application.Run(new Form1());

            AppDomain currentDomain = AppDomain.CurrentDomain;
        }

        public static void StartBrowserProxy()
        {
            FiddlerProxy.Start();
        }
    }
}
