using System;
using System.IO;
using System.Threading.Tasks;
using Squirrel;
using System.Linq;
using ServiceStack;
using System.Windows.Forms;

namespace ArmadaCollector.Utils
{
    public static class AppUpdater
    {
        public static async void RunUpdater()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/Pengii/ArmadaCollector-bin"))
                {
                    SquirrelAwareApp.HandleEvents(
                      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                      onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                      onAppUninstall: v => mgr.RemoveShortcutForThisExe());

                    await mgr.UpdateApp();
                    await mgr.CreateUninstallerRegistryEntry();
                }
            }
            catch
            {
                Bot.Log("Failed to update!");
            }

        }
    }
}
