using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CDesktopWallper
{
    public class Size
    {

        
        public virtual int Width { get; set; }

        
        public virtual int Height { get; set; }
    }
    
    public class WallperDescription
    {
    
        public virtual string Url { get; set; }

        public string  ThumbUrl { get; set; }
    
        public virtual Size Size { get; set; }

    
        public virtual string LocalPath { get; set; }

    
        public virtual string Tags { get; set; }
    }
}
