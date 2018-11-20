using ClientScript;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Retyped.dom;

namespace CDesktopWallper
{

    public class ClientSettingData : IClientSettingData
    {
        private bool _AutoWallper;
        public bool AutoWallper
        {
            get
            {
                return _AutoWallper;
            }
            set
            {
                ClientSetting.Set(nameof(AutoWallper), value);
                _AutoWallper = value;
            }
        }
        public string WallerSource { get; set; }
        public List<WallperDescription> Wallpers { get; set; }
        public List<string> UrlSubscriptions { get; set; }
        public List<string> Keywords { get; set; }
        public string Locale { get; set; }
    }
}
