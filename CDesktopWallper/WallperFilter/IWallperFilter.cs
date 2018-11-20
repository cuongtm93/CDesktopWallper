using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    interface IWallperFilter
    {
       bool Next(WallperDescription wallper);
    }
}
