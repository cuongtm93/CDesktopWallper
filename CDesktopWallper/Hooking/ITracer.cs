using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    interface ITracer<T>
    {
        void Trace(MethodBase method, object[] args);
    }
}
