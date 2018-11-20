using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge;
using Retyped;
using static Retyped.dom;
using Console = System.Console;

namespace ClientScript
{
    public class Resource
    {
        public static Resource Instance => new Resource();
        public string LocalWallperWebViewWS => WsAddress("LocalWallperWebViewWS");
        public string InternetWallperWebViewWS => WsAddress("InternetWallperWebViewWS");
        public string SettingWebViewWS => WsAddress("SettingWebViewWS");

        public string WsAddress(string name) => $"ws://{window.location.hostname}:5000/{name}";
        public string ComponentUrl(string name) => $"/Components/{name}.htm";

    }
}
