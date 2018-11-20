using FluentScheduler;
using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using WebSocketSharp.Server;

namespace CDesktopWallper.Frontend
{

    public class InternetWallperWebViewWS : WebSocketBehavior
    {
        private readonly IDesktop _desktop;
        private static readonly log4net.ILog _log =
                log4net.LogManager.
                GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InternetWallperWebViewWS()
        {
            this._desktop = Kernel.Resolve<IDesktop>();
        }
       
        protected override void OnError(ErrorEventArgs e)
        {
            _log.Error("Error " + e.Message);
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            var data = WsCommandProc.Parse(e.Data);
            switch (data.Command)
            {
                case "ListAll":

                    ListAll();
                    break;

                case "SetWallper":

                    this._desktop.SetWallper(new WallperDescription() { Url = data.JsonData }, WallperStyle.Centered);
                    break;

                default:
                    break;
            }
        }
        private void ListAll()
        {
            Task.Run(() =>
            {
                IWallperSource wallperSource = Kernel.Resolve<IWallperSource>(nameof(InternetWallperSource));
                var wallpers = wallperSource.GetWallpers().OrderBy(x => Guid.NewGuid());
                var SetListWallperCommand = new WsCommand()
                {
                    Command = "SetListWallperCommand",
                    JsonData = JsonConvert.SerializeObject(wallpers)
                };
                Send(WsCommandProc.ToString(SetListWallperCommand));
            });
        }
    }
}
