using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace CDesktopWallper.Frontend
{
    public class WsServer : IWsServer
    {
        private const int port = 5000;
        public WebSocketServer ws;

        public void Start()
        {
            ws = new WebSocketServer($"ws://0.0.0.0:{port}");
            ws?.AddWebSocketService<LocalWallperWebViewWS>($"/{nameof(LocalWallperWebViewWS)}");
            ws?.AddWebSocketService<SettingWebViewWS>($"/{nameof(SettingWebViewWS)}");
            ws?.AddWebSocketService<InternetWallperWebViewWS>($"/{nameof(InternetWallperWebViewWS)}");
            ws?.Start();
        }
        public WebSocketServiceManager Service
        {
            get => this.ws?.WebSocketServices;
        }

        public void SendToPath(string path, string message)
        {
            var session = Service.Hosts.FirstOrDefault(h => h.Path == path)?.Sessions;
            session?.Broadcast(message);
        }

        public void Broadcast(string message)
        {
            this.Service?.Broadcast(message);
        }
    }
}
