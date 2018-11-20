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
using CDesktopWallper.Extensions;
namespace CDesktopWallper.Frontend
{
    public class LocalWallperWebViewWS : WebSocketBehavior, IConsumer<WallperSourceChangedEvent>
    {
        private readonly IDesktop _desktop;
        private static readonly log4net.ILog _log =
                log4net.LogManager.
                GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        const int perPage = 9;
        public LocalWallperWebViewWS()
        {
            this._desktop = Kernel.Resolve<IDesktop>();
        }
        protected override void OnOpen()
        {

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
                    ListAll(page : int.Parse(data.JsonData));
                    this.Publish(new WallperSourceChangedEvent(""));
                    break;
                case "SetWallper":
                    var basepath = Directory.GetCurrentDirectory() + @"\Frontend\";
                    this._desktop.SetWallper(new WallperDescription() { LocalPath = basepath + data.JsonData.Replace("/", "\\") }, WallperStyle.Centered);
                    break;
                default:
                    break;
            }
        }
        private void ListAll(int page)
        {
            Task.Run(() =>
            {
                IWallperSource wallperSource = Kernel.Resolve<IWallperSource>(nameof(LocalWallperSource));
                var wallpers = wallperSource.GetWallpers(page, perPage).OrderBy(x => Guid.NewGuid());
                foreach (var wallper in wallpers)
                {
                    wallper.LocalPath = Path.GetFileName(wallper.LocalPath);
                }
                var SetListWallperCommand = new WsCommand()
                {
                    Command = "SetListWallperCommand",
                    JsonData = JsonConvert.SerializeObject(wallpers)
                };
                Sessions.Broadcast(WsCommandProc.ToString(SetListWallperCommand));
            });
        }

        public void HandleEvent(WallperSourceChangedEvent eventMessage)
        {
            //WsServer.Service.Broadcast($"WallperSource : {eventMessage.NewSource} at {DateTime.Now}");
        }
    }
}
