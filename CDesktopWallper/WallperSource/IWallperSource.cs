using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IWallperSource
    {
        List<WallperDescription> GetWallpers(int page = 0, int perPage = 0);
    }
}
