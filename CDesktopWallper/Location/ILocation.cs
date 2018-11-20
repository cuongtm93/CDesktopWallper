using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface ILocation
    {
        /// <summary>
        ///  Get country and city
        /// </summary>
        /// <returns></returns>
        GeoData Get();
    }
}
