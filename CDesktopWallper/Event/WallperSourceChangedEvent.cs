using CDesktopWallper.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace CDesktopWallper
{
    /// <summary>
    /// Thay đổi nguồn tải hình
    /// </summary>
    public class WallperSourceChangedEvent
    {
        public WallperSourceChangedEvent(string newSource)
        {
            this.NewSource = newSource;
        }
        public string NewSource { get; set; }
    }
}
