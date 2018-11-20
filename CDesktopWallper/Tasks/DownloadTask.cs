using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CDesktopWallper.Extensions;
using MSBuilder;

namespace CDesktopWallper
{
    class DownloadTask : CTask
    {
        private readonly ISettingData _setting;
        public DownloadTask()
        {
            this._setting = Kernel.Resolve<ISettingData>();
        }
        public override void Action()
        {
            var task = new DownloadFile
            {
                DestinationFolder = System.IO.Directory.GetCurrentDirectory(),
                SourceUrl = "https://www.nuget.org/api/v2/package/MSBuilder/0.1.0",
            };
            task.Execute();

        }
        public override void Trigger()
        {
            this.Clock.Interval = 1 * Scalar.Minute;
        }
    }
}
