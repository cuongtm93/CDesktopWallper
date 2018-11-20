using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    public class BrowserCacheMiddleWare : OwinMiddleware
    {
        public BrowserCacheMiddleWare(OwinMiddleware next) : base(next)
        {

        }
        public override Task Invoke(IOwinContext context)
        {
            var request = context.Request.Path.Value;
            var cachedTypes = new List<string>() { "jpg", "jpeg", "png", "gif" };
            foreach (var type in cachedTypes)
            {
                if (request.Contains(type))
                {
                    context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
                    return Next.Invoke(context);
                }
            }
            return Next.Invoke(context);
        }
    }
}
