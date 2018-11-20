using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper.Extensions;
using CDesktopWallper.Frontend;

namespace CDesktopWallper
{
    class FileSizeFilter : IWallperFilter
    {
        private readonly IWsServer wsServer;
        public FileSizeFilter()
        {
            this.wsServer = Kernel.Resolve<IWsServer>();

        }
        public bool Next(WallperDescription wallper)
        {
            var path = string.Empty;

            if (wallper.LocalPath.IsNotNullOrWhiteSpace())
                path = wallper.LocalPath;

            if (wallper.Url.IsNotNullOrWhiteSpace())
                path = wallper.Url;

            if (path.IsNullOrWhiteSpace())
                return false;

            // local file
            if (!path.FromInternet())
            {
                System.IO.FileInfo finfo = new System.IO.FileInfo(path);
                var totalKBytes = finfo.Length / 1024;
                if (totalKBytes < 100)
                    return false;

                return true;
            }

            // remote file
            try
            {
                var _client = new WebClient();
                using (_client)
                {
                    System.IO.Stream downloadStream = _client.OpenRead(path);
                    using (downloadStream)
                    {
                        Int64 totalKBytes = Convert.ToInt64(_client.ResponseHeaders["Content-Length"]) / 1024;
                        if (totalKBytes < 200)
                            return false;
                        return true;
                    }
                }
            }
            catch(Exception err)
            {
                this.wsServer.SendToPath("/InternetWallperWebViewWS", $"Exception :{err.Message}");
                return false;
            }
        }

    }
}
