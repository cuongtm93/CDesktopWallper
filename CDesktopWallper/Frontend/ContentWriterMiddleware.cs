using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
namespace CDesktopWallper.Frontend
{
    class ContentWriterMiddleware : OwinMiddleware
    {
        private static readonly ImageConverter _imageConverter = new ImageConverter();
        public ContentWriterMiddleware(OwinMiddleware next) : base(next)
        {

        }
        public override Task Invoke(IOwinContext context)
        {
            var filePath = $"./Frontend/{context.Request.Path.Value}";
            if (context.Response.ContentType == "image/jpeg")
                return RenderThumbnailWinApi(context, filePath);

            // nội dung thông thường js + css ...
            if (!File.Exists(filePath))
                return context.Response.WriteAsync(string.Empty);

            var content = File.ReadAllBytes(filePath);
            return context.Response.WriteAsync(content);

        }

        public Task RenderThumbnailWinApi(IOwinContext context, string filePath)
        {
            int maxWidth = MaxThumbWidth();

            var bytes = ImageToBytes(WindowsThumbnailProvider.GetThumbnail(
                 filePath, maxWidth, maxWidth, ThumbnailOptions.ThumbnailOnly
                 ));

            return context.Response.WriteAsync(bytes);
        }
        public int MaxThumbWidth()
        {
            var ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

            // tablet hoặc mobile 
            if(ScreenWidth <= 1024)
            {
                return 600;
            }
            else
            {
                return (int) (ScreenWidth / 3.2f);
            }
        }
        public Task RenderThumbnailDotNet(IOwinContext context, string filePath)
        {
            int maxWidth = MaxThumbWidth();
            var image = Image.FromFile(filePath);
            var fileSize = new FileInfo(filePath).Length;

            // file ảnh nhỏ hơn 1MB và chiều rộng < maxWidth
            if (fileSize <= (1024 * 1024) && image.Width < maxWidth)
                return context.Response.WriteAsync(File.ReadAllBytes(filePath));


            // file ảnh lớn hơn 1 MB hoặc chiều rộng >= maxWidth 
            var bytes = GetThumbnail(image, maxWidth);

            // dung lượng sau thumbnail còn lớn hơn cả ảnh gốc
            if (bytes.Length >= fileSize)
                return context.Response.WriteAsync(File.ReadAllBytes(filePath));


            return context.Response.WriteAsync(bytes);
        }
        public byte[] GetThumbnail(Image image, int thumbWidth)
        {

            float ratio = image.Width / thumbWidth;
            var thumb = image.GetThumbnailImage(thumbWidth, (int)(image.Height / ratio), null, IntPtr.Zero);
            var bytes = ImageToBytes(thumb);
            image.Dispose();
            thumb.Dispose();
            return bytes;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte[] ImageToBytes(Image image) => (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
    }
}
