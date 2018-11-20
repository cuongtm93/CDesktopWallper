using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Newtonsoft.Json;
using Retyped;
using Shared;
using static Retyped.dom;
using Console = System.Console;

namespace ClientScript
{

    public class InternetWallperWebViewWSClient
    {
        public static WebSocket Socket = new WebSocket(Resource.Instance.InternetWallperWebViewWS);
       
        public HTMLDivElement Loading()
        {
            return new HTMLDivElement()
            {
                className = "animated fadeIn",
                innerHTML = new HTMLDivElement()
                {
                    className = "row",
                    id = "InternetWallperWebView",
                    innerHTML = new HTMLDivElement()
                    {
                        className = "loader",
                    }.outerHTML
                }.outerHTML
            };
        }

        public InternetWallperWebViewWSClient()
        {
            App.SetTitle("Danh sách ảnh lưu trên mạng");
            App.SetBreadcrumb("Ảnh", "Trên mạng");
            App.Append(Loading());
            Socket.onopen += (open) =>
            {
                var ListAll = new WsCommand()
                {
                    Command = "ListAll",
                    JsonData = string.Empty
                };
                Socket.send(Json.Stringify(ListAll));
            };

            Socket.onmessage += (MessageEvent message) =>
            {
                try
                {
                    var command = Json.Parse(message.data.As<string>()).As<WsCommand>();
                    switch (command.Command)
                    {
                        case "SetListWallperCommand":
                            ParseWallpers(message);
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
            Socket.onerror += (error) =>
            {
                Console.WriteLine(error);
            };
        }


        public static void SetWallper(HTMLButtonElement element)
        {
            string src = string.Empty;
            var cardbody = element.parentNode.parentNode;
            src = cardbody.lastChild.As<HTMLImageElement>().getAttribute("data-src");
            var setWallperCmd = new WsCommand()
            {
                Command = "SetWallper",
                JsonData = src
            };

            Socket.send(Json.Stringify(setWallperCmd));
        }

        public void ParseWallpers(MessageEvent message)
        {
            var command = Json.Parse(message.data.As<string>()).As<WsCommand>();
            var wallpers = Json.Parse(command.JsonData).As<List<CDesktopWallper.WallperDescription>>();
            if (wallpers.Count == 0)
            {
                alert("Không tìm thấy kết quả nào");
            }
            var page = new WallperPage();
            foreach (var wallper in wallpers)
            {
                var wallperPreviewcard = new WallperPreviewCard()
                {
                    Status = "internet",
                    Title = "Hình nền",
                    Wallper = wallper.Url,
                    Thumb = wallper.ThumbUrl
                };
                page.Add(wallperPreviewcard);
            };

            document.getElementById("InternetWallperWebView").innerHTML = page.ToString();

            var setWallperButtons = document.getElementsByName("SetWallper");
            for (int i = 0; i < setWallperButtons.length; i++)
            {
                HTMLButtonElement element = setWallperButtons[i].As<dynamic>();
                setWallperButtons[i].onclick = (e) =>
                {
                    SetWallper(element);
                };
            }
        }
    }
}
