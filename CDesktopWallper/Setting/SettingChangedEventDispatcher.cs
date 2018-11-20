using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper;
using Ninject;
namespace CDesktopWallper
{
    class SettingChangedEventDispatcher : IConsumer<SettingChanged>
    {
        private readonly IEventPublisher eventPublisher;
        public SettingChangedEventDispatcher()
        {
            this.eventPublisher = Kernel.Modules.Get<IEventPublisher>();
        }
        public void HandleEvent(SettingChanged eventMessage)
        {
            // khi setting IWallperSource thay đổi
            if (eventMessage.EventArg.Key == nameof(IWallperSource))
                this.eventPublisher.Publish(new CDesktopWallper.WallperSourceChangedEvent(eventMessage.EventArg.New));
        }
    }
}
