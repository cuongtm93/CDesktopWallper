using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    interface ITag
    {
        /// <summary>
        ///  Lấy chủ đề của ảnh
        /// </summary>
        /// <param name="ImagePath">Đường dẫn tới ảnh</param>
        /// <returns></returns>
        string Reveal(string ImagePath);
    }
}
