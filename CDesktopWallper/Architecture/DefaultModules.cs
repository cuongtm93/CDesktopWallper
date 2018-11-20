using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper.Frontend;
using Ninject;
using Ninject.Modules;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    class DefaultModules : NinjectModule
    {
        public override void Load()
        {
            // importances 
            Bind<ISetting>().To<Setting>().InSingletonScope();

            Bind<IClientSettingData>().To<SettingData>().InSingletonScope();

            Bind<ISubscriptionService>().To<SubscriptionService>().InSingletonScope();
            Bind<IEventPublisher>().To<EventPublisher>().InSingletonScope();
            Bind<IDesktop>().To<Desktop>().InSingletonScope();

            Bind<ITag>().To<Tag>().InSingletonScope();

            //downloader
            Bind<IDownloader>().To<Downloader>();

            // images sources
            Bind<IWallperSource>().To<LocalWallperSource>().InSingletonScope().Named(nameof(LocalWallperSource));
            Bind<IWallperSource>().To<InternetWallperSource>().InSingletonScope().Named(nameof(InternetWallperSource));

            // search engines
            Bind<ISearch>().To<GoogleSearchImage>().InSingletonScope().Named(nameof(GoogleSearchImage));
            Bind<ISearch>().To<WebSearchImage>().InSingletonScope().Named(nameof(WebSearchImage));
            Bind<ISearch>().To<PexcelsSearchImage>().InSingletonScope().Named(nameof(PexcelsSearchImage));

            // filters
            Bind<IWallperFilter>().To<PathFilter>().InSingletonScope();
            Bind<IWallperFilter>().To<FileSizeFilter>().InSingletonScope();

            //effects
            Bind<IEffect>().To<WaterMarkEffect>().InSingletonScope();

            //localizations
            Bind<ILocalizationService>().To<LocalizationService>();
            Bind<ILocation>().To<Location>();
            Bind<IDeviceLocation>().To<DeviceLocation>();

            // serialzer 
            Bind<ISerializer<string>>().To<JsonSerializer>();

            // websocket server
            Bind<IWsServer>().To<WsServer>().InSingletonScope();
        }
    }

}
