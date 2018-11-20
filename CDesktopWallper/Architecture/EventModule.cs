using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper;

namespace CDesktopWallper
{
    class EventModules : NinjectModule
    {
        public override void Load()
        {
            Bind<IConsumer<WallperSourceChangedEvent>>().To<CDesktopWallper.Frontend.LocalWallperWebViewWS>().InSingletonScope();
            //Bind<IConsumer<WallperSourceLoadCompletedEvent>>().To<WallperSourceLoadCompletedEvent_Handler>();
        }
    }
}
