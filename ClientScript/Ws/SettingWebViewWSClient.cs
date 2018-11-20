using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Retyped.dom;
using Bridge;
using Newtonsoft.Json;
using Shared;
using CDesktopWallper;
using static Retyped.jquery;
using ClientScript.Exensions;
namespace ClientScript
{
    public class SettingWebViewWSClient
    {
        public static WebSocket Socket = new WebSocket(Resource.Instance.SettingWebViewWS);
        public SettingWebViewWSClient()
        {
            App.SetTitle("Tự động chuyển hình nền");
            App.SetBreadcrumb("Tính năng", "Tự động đổi hình nền");

            Task.Run(async () =>
            {
                var setting = await Component.GET("Setting");
                App.Append(setting);

                var clientSetting = new ClientSetting();
                clientSetting.OnComplete = () =>
                {
                    LoadSettings(clientSetting);
                };

                BtnActiveOnClick();
            });
        }

        public void LoadSettings(ClientSetting clientSetting)
        {
            var settingItem = jQuery.select("input[id^='setting.']").As<HTMLInputElement[]>();
            foreach (var item in settingItem)
            {
                void SetChecked(string _name, bool _value)
                {
                    var id = $"setting.{_name}";
                    if (_value)
                    {
                        document.getElementById(id).setAttribute("checked", "true");
                    }
                    else
                        document.getElementById(id).removeAttribute("checked");
                }
                var name = item.id.Split(".".ToCharArray())[1];
                bool value = false;
                switch (name)
                {
                    case "AutoWallper":
                        value = clientSetting.Data.GetField<bool>(name);
                        break;

                    case "InternetWallperSource":
                        value = clientSetting.Data.WallerSource == "InternetWallperSource";
                        break;

                    case "LocalWallperSource":
                        value = clientSetting.Data.WallerSource == "LocalWallperSource";
                        break;
                    default:
                        break;
                }

                SetChecked(name, value);

            }
        }
        public static void Start()
        {
            Socket.send(Json.Stringify(new WsCommand()
            {
                Command = "Start"
            }));
        }

        public static void Stop()
        {
            Socket.send(Json.Stringify(new WsCommand()
            {
                Command = "Stop"
            }));
        }

        private void BtnActiveOnClick()
        {
            var btnActive = document.getElementById("btnActive");
            if (btnActive != null)
                btnActive.onclick = (e) =>
                {
                    if (btnActive.innerText == "Kích hoạt")
                    {
                        Start();
                        btnActive.innerText = "Ngưng";
                    }
                    else
                    {
                        Stop();
                        btnActive.innerText = "Kích hoạt";
                    }
                };
        }

    }
}
