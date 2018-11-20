using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Newtonsoft.Json;
using Retyped;
using static Retyped.dom;
using Console = System.Console;
using Shared;
namespace ClientScript
{

    public class LocalWallperWebViewWSClient
    {
        public static WebSocket Socket = new WebSocket(url: Resource.Instance.LocalWallperWebViewWS);
        public static int currentPage = 1;
        public HTMLDivElement Loading()
        {

            return new HTMLDivElement()
            {
                className = "animated fadeIn",
                innerHTML = new HTMLDivElement()
                {
                    className = "row",
                    id = "LocalWallperWebView",
                    innerHTML = new HTMLDivElement()
                    {
                        className = "loader"
                    }.outerHTML
                }.outerHTML
            };
        }

        private static void ViewPage(int page)
        {
            Console.WriteLine($"Đang hiển thị trang {page}");
            var ListAll = new WsCommand()
            {
                Command = "ListAll",
                JsonData = page.ToString()
            };
            Socket.send(Json.Stringify(ListAll));
        }
        public LocalWallperWebViewWSClient()
        {
            App.SetTitle("Danh sách ảnh lưu trên máy");
            App.SetBreadcrumb("Ảnh", "Trên máy");
            App.Append(Loading());
            Socket.onopen += (open) =>
            {
                ViewPage(currentPage);
            };

            Socket.onmessage += (MessageEvent message) =>
            {
                try
                {
                    var command = Json.Parse(message.data.As<string>()).As<WsCommand>();
                    switch (command.Command)
                    {
                        case "SetListWallperCommand":
                            var wallpers = Json.Parse(command.JsonData).As<List<CDesktopWallper.WallperDescription>>();
                            if (wallpers.Any())
                                ParseWallpers(wallpers);
                            else
                            {
                                currentPage = 0;
                                Console.WriteLine($"Không có trang {currentPage}, đang quay về trang đầu");
                            }
                                

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

            document.onscroll += (UIEvent evt) =>
            {
                if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight )
                {
                    currentPage = currentPage + 1;
                    ViewPage(currentPage);
                    window.scrollTo(0, 0);
                    System.Threading.Thread.Sleep(1000);
                }

                if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight)
                {

                }
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
        public static void ParseWallpers(List<CDesktopWallper.WallperDescription> wallpers)
        {
            var page = new WallperPage();
            foreach (var wallper in wallpers)
            {
                var wallperPreviewcard = new WallperPreviewCard()
                {
                    Status = "Đã tải",
                    Title = wallper.LocalPath,
                    Wallper = "wallpers/" + wallper.LocalPath
                };
                page.Add(wallperPreviewcard);
            };

            document.getElementById("LocalWallperWebView").innerHTML = page.ToString();
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
