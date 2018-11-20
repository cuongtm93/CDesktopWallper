using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public class SettingChangedEventArg
    {
        public string Key { get; set; }
        public dynamic Old { get; set; }
        public dynamic New { get; set; }
    }
    public class SettingChanged
    {
        public SettingChanged(SettingChangedEventArg arg)
        {
            this.EventArg = arg;
        }
        public SettingChangedEventArg EventArg { get; set; }
    }
}
