using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IClientSettingData
    {
        bool AutoWallper { get; set; }
        string WallerSource { get; set; }

        List<WallperDescription> Wallpers { get; set; }

        List<string> UrlSubscriptions { get; set; }

        List<string> Keywords { get; set; }

        string Locale { get; set; }

    }
}
