using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    public class InternetWallperSource : IWallperSource
    {
        private readonly ISearch _webSearchImage;

        private static readonly log4net.ILog _log =
              log4net.LogManager.
              GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public InternetWallperSource()
        {
            this._webSearchImage = Kernel.Resolve<ISearch>(nameof(GoogleSearchImage));
        }
        public List<WallperDescription> GetWallpers(int page = 0, int perPage = 0)
        {
            List<WallperDescription> wallperList = this._webSearchImage.Search("hình nền wallper thảo nguyên");

            // lọc trùng nhau
            wallperList = wallperList.Distinct().ToList();

            // lọc ảnh quá bé và đường dẫn url không hợp lệ
            var invalids  = wallperList.GetInvalids();
            wallperList.RemoveAll(w => invalids.Contains(w));
            return wallperList;
        }
    }
}
