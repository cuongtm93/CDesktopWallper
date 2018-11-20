using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface ISearch
    {
        List<WallperDescription> Search<T>(T keyword);

    }
}
