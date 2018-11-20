using NConcern;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class LoggingHooking : IApplicationHooking
    {

        public void Start()
        {
            Aspect.Weave<Logging>(typeof(IDesktop));
            Aspect.Weave<Logging>(typeof(ICTaskImplement));
        }

        public void Stop()
        {
            Aspect.Release<Logging>();
        }
    }
}
