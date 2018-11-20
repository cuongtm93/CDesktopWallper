using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface ISetting
    {
        SettingData Data { get; set; }

        void Load();

        void Save();
    }
}
