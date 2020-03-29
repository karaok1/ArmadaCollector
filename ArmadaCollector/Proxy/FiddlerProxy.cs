using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArmadaCollector.Proxy
{
    public static class FiddlerProxy
    {
        private static SessionStateHandler _beforeResponse;
        private static SessionStateHandler _beforeRequest;

        public static void Start()
        {
            FiddlerApplication.Shutdown();
            FiddlerApplication.OnValidateServerCertificate += FiddlerApplication_OnValidateServerCertificate;
            SessionStateHandler _bResp;
            if ((_bResp = _beforeResponse) == null)
            {
                _bResp = (_beforeResponse = new SessionStateHandler(BeforeResponse));
                FiddlerApplication.BeforeResponse += _bResp;
            }
            SessionStateHandler _bReq;
            if ((_bReq = _beforeRequest) == null)
            {
                _bReq = (_beforeRequest = new SessionStateHandler(BeforeRequest));
                FiddlerApplication.BeforeRequest += _bReq;
            }
            InstallCert();
            FiddlerApplication.OnWebSocketMessage += FiddlerApplication_OnWebSocketMessage;
            FiddlerCoreStartupSettings startupSettings =
                new FiddlerCoreStartupSettingsBuilder()
                    .ListenOnPort(Server.FiddlerPort)
                    .DecryptSSL()
                    .OptimizeThreadPool()
                    .Build();

            Fiddler.FiddlerApplication.Startup(startupSettings);
        }

        private static async void FiddlerApplication_OnWebSocketMessage(object sender, WebSocketMessageEventArgs e)
        {
            #region FilterMessages
            if (e.oWSM.PayloadAsString().Contains("info"))
            {
                await Task.Run(() =>
                {
                    Bot.Log("collected");
                });
            }

            #endregion
        }

        private static void InstallCert()
        {
            try
            {
                if (!CertMaker.rootCertExists() && !CertMaker.createRootCert())
                {
                    throw new Exception("Could not create Root Certificate!");
                }
                if (!CertMaker.rootCertIsTrusted() && !CertMaker.trustRootCert())
                {
                    throw new Exception("Could not find valid Root Certificate for Fiddler!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Certificate Installer Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void FiddlerApplication_OnValidateServerCertificate(object sender, ValidateServerCertificateEventArgs e)
        {
            if (e.CertificatePolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return;
            }
            e.ValidityState = CertificateValidity.ForceValid;
        }

        private static void BeforeResponse(Session e)
        {
            e.bBufferResponse = true;
            e.utilDecodeResponse();
            try
            {
                if (e.GetResponseBodyAsString().Contains("game.gamePaused"))
                {
                    var body = e.GetResponseBodyAsString();
                    body = body.Replace("game.gamePaused", "game.gameResumed");
                    body = body.Replace("\"pagehide\" === t.type || \"blur\" === t.type || \"pageshow\" === t.type || \"focus\" === t.type ? void(\"pagehide\" === t.type || \"blur\" === t.type ? this.game.focusLoss(t) : \"pageshow\" !== t.type && \"focus\" !== t.type || this.game.focusGain(t)) : void(this.disableVisibilityChange || (document.hidden || document.mozHidden || document.msHidden || document.webkitHidden || \"pause\" === t.type ? this.game.gamePaused(t) : this.game.gameResumed(t)))", "false");
                    e.utilSetResponseBody(body);
                }
            }
            catch (Exception ex)
            {
                Bot.Log(ex.ToString());
            }
        }

        private static void BeforeRequest(Session e)
        {
            e.bBufferResponse = true;
            if (e.RequestHeaders.ExistsAndContains("Sec-WebSocket-Extensions", "permessage-deflate"))
            {
                e.RequestHeaders.Remove("Sec-WebSocket-Extensions");
            }
        }
    }
}
