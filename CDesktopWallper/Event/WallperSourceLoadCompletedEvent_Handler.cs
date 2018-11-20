using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    class WallperSourceLoadCompletedEvent_Handler : IConsumer<WallperSourceLoadCompletedEvent>
    {
        private readonly ISetting _setting;
        public WallperSourceLoadCompletedEvent_Handler()
        {
            this._setting = Kernel.Resolve<ISetting>();
        }
        public void HandleEvent(WallperSourceLoadCompletedEvent eventMessage)
        {
            this._setting.Data.Wallpers =eventMessage.Wallpers;
            this._setting.Save();
        }
    }
}
