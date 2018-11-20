using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace CDesktopWallper
{

    public class Kernel
    {
        public static StandardKernel Modules;
        static Kernel()
        {
            Modules = new StandardKernel();

            Modules.Load<DefaultModules>();
            Modules.Load<EventModules>();
        }
        public static T Resolve<T>()
        {
            return Modules.Get<T>();
        }

        public static T Resolve<T>(string name)
        {
            if (Modules.CanResolve<T>(name))
                return Modules.Get<T>(name);

            return default;
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return Modules.GetAll<T>();
        }

        public static IEnumerable<T> ResolveAll<T>(string name)
        {
            return Modules.GetAll<T>(name);
        }
    }
}
