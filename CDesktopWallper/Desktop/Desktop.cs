using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using ImageProcessor.Imaging.Filters.Photo;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    public class Desktop : IDesktop
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;



        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        private readonly IEnumerable<IEffect> _effects;
        private readonly IDownloader _downloader;
        private readonly ISetting _setting;
        public Desktop()
        {
            this._effects = Kernel.ResolveAll<IEffect>();
            this._downloader = Kernel.Resolve<IDownloader>();
            this._setting = Kernel.Resolve<ISetting>();
        }
        public void SetWallper(WallperDescription wallper, WallperStyle style)
        {
            try
            {
                if (wallper.Url.IsNotNullOrWhiteSpace() && wallper.Url.FromInternet())
                {
                    string DownloadedFile = string.Empty;
                    Task.Run(() =>
                    {
                        DownloadedFile = this._downloader.DownloadFile(wallper.Url, Directory.GetCurrentDirectory() + "\\Frontend\\Wallpers\\");
                        wallper.LocalPath = DownloadedFile;
                    }).Wait();

                    WallperRegistry(DownloadedFile, style);
                    return;
                }
                                
                if (wallper.LocalPath.IsNotNullOrWhiteSpace())
                {
                    WallperRegistry(wallper.LocalPath, style);
                    return;
                }

            }
            catch (Exception err)
            {
                Console.WriteLine("Exception : " + err.Message);
            }
        }

        private void WallperRegistry(string file, WallperStyle style)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (style == WallperStyle.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == WallperStyle.Centered)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == WallperStyle.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }
            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                file,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

            key.Dispose();
        }
    }
}
