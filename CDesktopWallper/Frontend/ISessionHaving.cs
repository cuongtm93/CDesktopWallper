using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace CDesktopWallper.Frontend
{
    public interface ISessionHaving
    {
        WebSocketSessionManager Session { get; set; }
    }
}
