using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IDownloader 
    {
        string DownloadString(string url);
        string DownloadFile(string url, string Directory);

        //string BatchDownloadFile(List<string> urls, string Directory);

    }
}
