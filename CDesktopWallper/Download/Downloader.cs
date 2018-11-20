using MSBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class Downloader : IDownloader
    {
     
        public string DownloadFile(string url, string directory)
        {
            var downloader = new DownloadFile
            {
                DestinationFolder = directory,
                SourceUrl = url
            };

            var success = downloader.Execute();
            if (success)
                return downloader.DownloadedFile;
            else
                return string.Empty;
        }

        public string DownloadString(string url)
        {
            var _web = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            using (_web)
            {
                return _web.DownloadString(url);
            }
        }
    }
}
