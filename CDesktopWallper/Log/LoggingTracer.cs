using CDesktopWallper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggingTracers
{
    public class LoggingTracer : ITracer<LoggingTracer>
    {
        private static readonly log4net.ILog log =
                log4net.LogManager.
                GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Trace(MethodBase method, object[] args)
        {
            
            switch (method.Name)
            {
                case "SetWallper":
                    var wallper = args[0] as WallperDescription;
                    var style = (WallperStyle)args[1];
                    log.Info($"SetWallper : {wallper.Url} , {style}");
                    break;
                case "WallperRegistry":
                    string file = (string)args[0];
                    log.Info($"WallperRegistry : {file}");
                    break;
                default:
                    log.Info("Enter : " + method.Name);
                    break;
            }
        }
    }

    public class ITaskScheduler : ITracer<LoggingTracer>
    {
        private static readonly log4net.ILog log =
                log4net.LogManager.
                GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void Trace(MethodBase method, object[] args)
        {
            log.Info("ITaskScheduler : " + method.Name);
        }
    }

}
