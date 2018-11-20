using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace CDesktopWallper
{
    public class DeviceLocation : IDeviceLocation
    {
        private readonly GeoCoordinateWatcher _watcher;
        public DeviceLocation()
        {
            this._watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        }
        public MapPoint GetLocation()
        {
            var positionAvalable = false;
            this._watcher.PositionChanged += (sender, e) =>
            {
                positionAvalable = true;
            };
            this._watcher.Start();
            while (!positionAvalable)
            {
                // just wait
            }
            return new MapPoint
            {
                lat = (float) this._watcher.Position.Location.Latitude,
                lng = (float) this._watcher.Position.Location.Longitude,
            };
        }
    }
}
