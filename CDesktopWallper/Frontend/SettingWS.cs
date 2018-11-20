using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
namespace CDesktopWallper.Frontend
{
    public class SettingWS : WebSocketBehavior , IConsumer<WallperSourceChangedEvent>
    {
        protected override void OnOpen()
        {
            
        }
        protected override void OnClose(CloseEventArgs e)
        {
            
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            
        }

        public void HandleEvent(WallperSourceChangedEvent eventMessage)
        {
            Send("Xin chào");
        }
    }
}
