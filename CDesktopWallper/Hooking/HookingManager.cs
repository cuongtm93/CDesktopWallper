using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class HookingManager
    {
       
        public void Start()
        {
            Kernel.Modules.Bind<IApplicationHooking>().To<LoggingHooking>();

            var hookings = Kernel.ResolveAll<IApplicationHooking>().ToList();
            hookings.ForEach(hooking => hooking.Start());
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
