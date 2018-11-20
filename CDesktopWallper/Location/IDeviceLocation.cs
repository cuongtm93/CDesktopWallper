using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public struct MapPoint
    {
        public float lat;
        public float lng;
    }
    public interface IDeviceLocation
    {
        MapPoint GetLocation();
    }
}
