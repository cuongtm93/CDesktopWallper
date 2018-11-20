using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace CDesktopWallper
{
    public class Location : ILocation
    {
        private readonly IDownloader _downloader;
        private readonly IDeviceLocation _deviceLocation;
        public Location()
        {
            this._downloader = Kernel.Resolve<IDownloader>();
            this._deviceLocation = Kernel.Resolve<IDeviceLocation>();
        }

        public GeoData Get()
        {
            var mapPoint = this._deviceLocation.GetLocation();
            var json = this._downloader.DownloadString($"http://maps.googleapis.com/maps/api/geocode/json?latlng={mapPoint.lat},{mapPoint.lng}&sensor=false");
            var result = GoogleGeo.GeoLocationResult.FromJson(json).Results.First();
            return new GeoData()
            {
                Country = result.AddressComponents[5].LongName,
                Province = result.AddressComponents[4].LongName,
                District = result.AddressComponents[3].LongName,
                Ward = result.AddressComponents[2].LongName,
                SubWard = result.AddressComponents[1].LongName,
                Street = result.AddressComponents[0].LongName,
                FullAddress = result.FormattedAddress
            };
        }
    }
}
