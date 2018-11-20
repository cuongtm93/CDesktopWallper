using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class WallperSourceLoadCompletedEvent
    {
        public WallperSourceLoadCompletedEvent(string source,List<WallperDescription> wallpers)
        {
            this.Source = source;
            this.Wallpers = wallpers;
        }
        public string Source { get; set; }
        public List<WallperDescription> Wallpers { get; set; }
    }
}
