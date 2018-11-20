using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    public interface IWsServer
    {
        void Start();

        void SendToPath(string path, string message);

        void Broadcast(string message);
    }
}
