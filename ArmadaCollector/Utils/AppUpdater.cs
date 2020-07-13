using System;
using System.IO;
using System.Threading.Tasks;
using Squirrel;
using System.Linq;
using ServiceStack;
using System.Windows.Forms;
using System.ComponentModel;

namespace ArmadaCollector.Utils
{
    public static class AppUpdater
    {
        public static async void CheckForUpdates()
        {
            try
            {
                using (var mgr = await GetUpdateManager())
                    await SquirrelUpdate(mgr);
            }
            catch (Exception ex)
            {
                Bot.Log(ex.Message);
            }
        }

        private static async Task<UpdateManager> GetUpdateManager()
        {
            return await UpdateManager.GitHubUpdateManager("https://github.com/Pengii/ArmadaCollector-bin");
        }

        public static async Task RunUpdater()
        {
            try
            {
                Bot.Log("Check for updates...");
                bool updated;
                using (var mgr = await GetUpdateManager())
                {
                    SquirrelAwareApp.HandleEvents(
                      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                      onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                      onAppUninstall: v => mgr.RemoveShortcutForThisExe());
                    updated = await SquirrelUpdate(mgr);
                }

                if (updated)
                {
                    Bot.Log("Update complete, restarting");
                    UpdateManager.RestartApp();
                }
            }
            catch
            {
                Bot.Log("Failed to update!");
            }
        }

        private static async Task<bool> SquirrelUpdate(UpdateManager mgr, bool ignoreDelta = false)
        {
            try
            {
                Bot.Log($"Checking for updates (ignoreDelta={ignoreDelta})");
                var updateInfo = await mgr.CheckForUpdate(ignoreDelta);
                if (!updateInfo.ReleasesToApply.Any())
                {
                    Bot.Log("No new updates available");
                    return false;
                }
                var latest = updateInfo.ReleasesToApply.LastOrDefault()?.Version;
                var current = mgr.CurrentlyInstalledVersion();
                if (latest <= current)
                {
                    Bot.Log($"Installed version ({current}) is greater than latest release found ({latest}). Not downloading updates.");
                    return false;
                }
                if (IsRevisionIncrement(current?.Version, latest?.Version))
                {
                    Bot.Log($"Latest update ({latest}) is revision increment. Updating in background.");

                }
                Bot.Log($"Downloading {updateInfo.ReleasesToApply.Count} {(ignoreDelta ? "" : "delta ")}releases, latest={latest?.Version}");
                await mgr.DownloadReleases(updateInfo.ReleasesToApply);
                Bot.Log("Applying releases");
                await mgr.ApplyReleases(updateInfo);
                await mgr.CreateUninstallerRegistryEntry();
                Bot.Log("Done");
                return true;
            }
            catch (Exception ex)
            {
                if (ignoreDelta)
                    return false;
                if (ex is Win32Exception)
                    Bot.Log("Not able to apply deltas, downloading full release");
                return await SquirrelUpdate(mgr, true);
            }
        }

        private static void ShowErrorAndClose(string _text)
        {
            AutoClosingMessageBox.Show(
                text: _text,
                caption: "Error",
                timeout: 5000,
                buttons: MessageBoxButtons.OK,
                defaultResult: DialogResult.Yes);
            // close the form on the forms thread
            Application.Exit();
        }

        internal static void StartUpdate()
        {
            Bot.Log("Restarting...");
            UpdateManager.RestartApp();
        }

        private static bool IsRevisionIncrement(Version current, Version latest)
        {
            if (current == null || latest == null)
                return false;
            return current.Major == latest.Major && current.Minor == latest.Minor && current.Build == latest.Build
                   && current.Revision < latest.Revision;
        }
    }
}
