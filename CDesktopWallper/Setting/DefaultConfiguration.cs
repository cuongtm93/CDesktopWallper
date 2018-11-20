using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    class DefaultConfiguration : IDefaultConfiguration
    {
        public string IWallperSource => nameof(LocalWallperSource);
        public List<string> _wallpers => new List<string>();
        public List<string> UrlSubscription => new List<string>();
        public List<string> Keywords => new List<string>();
        public void Generate()
        {
            var setting = this.Serialize();
            System.IO.File.WriteAllText(Const.SettingFile, setting);
        }
    }
}
