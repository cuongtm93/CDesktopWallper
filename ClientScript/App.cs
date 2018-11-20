using Bridge;
using Newtonsoft.Json;
using System;
using static Retyped.dom;
using System.Linq;
using System.Collections.Generic;
namespace ClientScript
{
    public class App
    {

        #region properties
        public static Element GetAppMainWindows() => document.getElementsByClassName("content mt-3").SingleOrDefault();
        public static Element GetBreadcrumb() => document.getElementsByClassName("breadcrumb text-right").SingleOrDefault();

        public static HTMLCollectionOf<Element> GetAppTitle() => document.getElementsByClassName("page-title");

        #endregion

        #region methods
        public static string GetCurrentModule()
        {
            switch (window.location.pathname)
            {
                case "/local-wallpers.html":
                    return "LocalWallperWebViewWS";
                case "/tables-data.html":
                    return "InternetWallperWebViewWS";
                case "":
                case "/":
                case "/index.html":
                    return "Index";
                case "/auto-change-wallper.html":
                    return "TaskSchedulerWebViewWS";
                case "/modules.html":
                    return "ModulesWebViewWS";
                default:
                    return "unknown";
            }
        }
        public static void Append(string html)
        {
            var content = GetAppMainWindows();
            content.innerHTML += html;
        }
        public static void Append<T>(T element)
        {
            var content = GetAppMainWindows();
            content.appendChild<T>(element);
        }
        public static void SetBreadcrumb(List<string> directions)
        {
            var Br = GetBreadcrumb();
            Br.innerHTML = string.Empty;
            foreach (var direction in directions)
            {
                var li = new HTMLLIElement()
                {
                    innerHTML = direction,
                    className = "breadcrumb-item"
                };

                if (direction == directions.Last())
                    li.className += " active";

                Br.appendChild(li);
            }
        }
        public static void SetBreadcrumb(params string[] directions)
        {
            SetBreadcrumb(directions.ToList());
        }
        public static void SetTitle(string s)
        {
            var page_title = GetAppTitle();
            page_title[0].children[0].innerHTML = s;

        }

        /// <summary>
        ///  Nạp module javascript từ url
        /// </summary>
        /// <param name="url"></param>
        public static void RequireJS(string url)
        {
            var script = new HTMLScriptElement();
            script.addEventListener("load", (Event e) =>
            {
                console.log($"Module {url} đã nạp xong");
            });
            script.src = url;
            script.async = true;
            document.head.appendChild(script);
        }

        #endregion

        [Ready]
        public static void ExecuteRequestModule()
        {
            try
            {

                var currentModule = GetCurrentModule();
                switch (currentModule)
                {
                    case "Index":
                        var ads = new Kernel.AjaxTask()
                        {
                            Method = Kernel.Http.HttpMethod.GET,
                            Url = "/Templates/ad.htm",
                            Async = true
                        };

                        ads.Execute().GetAwaiter().OnCompleted(() => Append(ads.AjaxResult.As<string>()));

                        break;
                    case "LocalWallperWebViewWS":
                        new LocalWallperWebViewWSClient();
                        break;
                    case "InternetWallperWebViewWS":
                        new InternetWallperWebViewWSClient();
                        break;
                    case "TaskSchedulerWebViewWS":
                        new SettingWebViewWSClient();
                        break;
                    case "ModulesWebViewWS":
                        new ModulesWebViewWS();
                        break;
                    default:
                        App.PushMessage("Module này không sử dụng được");
                        break;
                }
            }
            catch (Exception err)
            {
                document.writeln("Lỗi khi khởi động ứng dụng : " + err.Message);
            }


        }

        [Ready]
        public static void Main()
        {
            //Retyped.jquery.jQuery.select()
            //Retyped.jquery.jQuery.select("body").As<dynamic>().toggleClass("open");
            //ContextMenu.Disable();
            //window.addEventListener("selectstart", (e) => { e.preventDefault(); });
        }
        
        //[Ready]
        public static void LazyImageLoad()
        {
            Retyped.jquery.jQuery.select(".lazy").As<dynamic>().Lazy(new
            {
                // your configuration goes here
                scrollDirection = "vertical",
                effect = "fadeIn",
                visibleOnly = true,
            });
        }

        [Ready]
        public static void OnError()
        {
            window.addEventListener("error", (Event e) =>
            {
                alert("Không tải được resouce");
            });
        }

        public static void PushMessage(string message)
        {
            Script.Get("Push.create(message)");
        }
    }
}