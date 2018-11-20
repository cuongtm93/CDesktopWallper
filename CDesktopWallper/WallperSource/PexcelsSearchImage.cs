using PexelsNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class PexcelsSearchImage : ISearch
    {
        private const string apiKey = "563492ad6f9170000100000147b95f140fe441b858072ac5940c9ba00";
        public List<WallperDescription> SearchByImage(Bitmap Image)
        {
            throw new NotImplementedException();
        }

        public List<WallperDescription> Search<T>(T keyword)
        {
            var _return = new List<WallperDescription>();
            switch (keyword)
            {
                case System.Drawing.Image img_keyword:
                    break;
                case string s:
                    _return = SearchForText(s);
                    break;
                default:
                    throw new NotSupportedException("Không hỗ trợ tìm kiếm theo từ khoá kiểu này");
            }
            return _return;
        }

        private List<WallperDescription> SearchForText(string keyword)
        {
            var client = new PexelsClient(apiKey);
            var results = client.SearchAsync(keyword).Result;
            var maxPage = results.TotalResults / results.PerPage;
            var _lock = new object();
            int randomPage = 0;
            lock (_lock)
            {
                randomPage = new Random().Next(maxPage);
            }
            results = client.SearchAsync(keyword, randomPage).Result;

            return results.Photos.Select(image =>new WallperDescription()
            {
                Url = image.Src.Original,
                ThumbUrl = image.Src.Tiny,
                Size = new Size()
                {
                    Height = image.Height,
                    Width = image.Width
                },
            }).ToList();
        }
    }
}
