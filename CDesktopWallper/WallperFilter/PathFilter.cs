using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    class PathFilter : IWallperFilter
    {
        public void Dispose()
        {

        }

        public bool Next(WallperDescription wallper)
        {
            // local filter ignore
            if (wallper.LocalPath.IsNotNullOrWhiteSpace())
                return true;

            // internet filter
            return wallper.Url.IsNotNullOrWhiteSpace()
                && wallper.Url.FromInternet()
                && !wallper.Url.EndsWith(".gif");
        }
    }
}
