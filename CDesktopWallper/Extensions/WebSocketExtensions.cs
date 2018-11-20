using CDesktopWallper.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace CDesktopWallper.Extensions
{
    public static class WebSocketExtensions
    {
        private static readonly IEventPublisher _eventPublisher;
        static WebSocketExtensions()
        {
            _eventPublisher = Kernel.Resolve<IEventPublisher>();
        }

        public static void Publish<T>(this WebSocketBehavior ws, T eventMessage)
        {
            _eventPublisher.Publish(eventMessage);
        }
    }
}
