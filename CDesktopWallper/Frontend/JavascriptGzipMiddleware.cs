using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    class JavascriptGzipMiddleware : OwinMiddleware
    {
        public JavascriptGzipMiddleware(OwinMiddleware next) : base(next)
        {
        }
        public static byte[] Compress(byte[] input)
        {
            using (var result = new MemoryStream())
            {
                var lengthBytes = BitConverter.GetBytes(input.Length);
                result.Write(lengthBytes, 0, 4);

                using (var compressionStream = new GZipStream(result,
                    CompressionMode.Compress))
                {
                    compressionStream.Write(input, 0, input.Length);
                    compressionStream.Flush();

                }
                return result.ToArray();
            }
        }

        public override Task Invoke(IOwinContext context)
        {
            var request = System.IO.Directory.GetCurrentDirectory() + "\\Frontend" + $"{ context.Request.Path.Value.Replace("/", "\\")}";
            if (request.EndsWith(".js"))
            {
                try
                {
                    var bytes = System.IO.File.ReadAllBytes(request);
                    bytes = Compress(bytes);
                    context.Response.Headers.Set("Content-Encoding", "gzip");
                    return context.Response.WriteAsync(bytes);
                }
                catch (Exception e)
                {
                    return context.Response.WriteAsync(e.Message);
                }

            }
            return Next.Invoke(context);
        }
    }
}
