using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    /// <summary>
    ///  Hiệu ứng chữ nổi trên hình 
    /// </summary>
    class WaterMarkEffect : IEffect
    {
        public void Apply(string path)
        {
            var factory = new ImageProcessor.ImageFactory();
            factory.Load(path);
            factory.Watermark(new ImageProcessor.Imaging.TextLayer()
            {
                Text = $"Thời điểm tải xuống : {DateTime.Now}",
                Position = new System.Drawing.Point()
                {
                    X = 0,
                    Y = 0
                },
                FontSize = 15,
                FontColor = System.Drawing.Color.Red
            });
            factory.Save(path);
            factory.Dispose();
        }
    }
}
