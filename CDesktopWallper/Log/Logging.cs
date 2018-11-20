using NConcern;
using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject;
using System.Linq;
using LoggingTracers;
using System.Runtime.CompilerServices;

namespace CDesktopWallper
{
    public class Logging : IAspect
    {
        
        public IEnumerable<IAdvice> Advise(MethodBase method)
        {
            yield return Advice.Basic.Before((instance, arguments) =>
            {

            });
        }
    }
}

