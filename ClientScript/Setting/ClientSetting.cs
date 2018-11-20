using System;
using ClientScript;
using Newtonsoft.Json;
using Shared;
using static Retyped.dom;

namespace CDesktopWallper
{
    public class ClientSetting : IClientSetting
    {
        public static WebSocket Socket = new WebSocket(Resource.Instance.SettingWebViewWS);
        public ClientSettingData Data { get; set; }
        public Action OnComplete;
        public ClientSetting()
        {
            Socket.onmessage = (message) =>
            {
                try
                {
                    var ws = JsonConvert.DeserializeObject<WsCommand>(message.data.As<string>());
                    switch (ws.Command)
                    {
                        case "READ":
                            Javascript.debugger();
                            this.Data = Json.Parse(ws.JsonData).As<ClientSettingData>();
                            OnComplete?.Invoke();
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    console.log(message.data);
                }

            };
            Socket.onopen = (open) =>
            {
                this.Load();
            };
        }

        public void Load()
        {
            var READ = new WsCommand()
            {
                Command = "READ"
            };
            Socket.send(Json.Stringify(READ));
        }

        public void Save()
        {

        }

        public static void Set(string name, object value)
        {
            var wsSetCommand = new WsCommand()
            {
                Command = "SET",
                JsonData = Json.Stringify(new SettingCommand()
                {
                    Name = name,
                    Value = value
                })
            };
            Socket.send(Json.Stringify(wsSetCommand));
        }
    }
}
