using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IDesktop
    {
        /// <summary>
        ///  Cài đặt màn hình nền cho máy tính
        /// </summary>
        /// <param name="wallper">Đường dẫn tới file trong local</param>
        /// <param name="style">Kiểu hình nền </param>
        void SetWallper(WallperDescription wallper, WallperStyle style);
    }
}
