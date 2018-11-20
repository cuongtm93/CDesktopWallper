using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IClientSetting
    {
        ClientSettingData Data { get; set; }

        void Load();

        void Save();
    }
}
