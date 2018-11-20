using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    public class MemCacheMiddleware : OwinMiddleware
    {
        public MemCacheMiddleware(OwinMiddleware next) : base(next)
        {

        }
        public override Task Invoke(IOwinContext context)
        {
            if (context.Request.Path.Value.EndsWith(".html"))
            {
                try
                {
                    var cached = context.Get<byte[]>("cached");
                    if (cached == default )
                    {
                        cached = System.IO.File.ReadAllBytes("./Frontend/index.html");
                        context.Set<byte[]>("cached", cached);
                    }
                    return context.Response.WriteAsync(cached);
                }
                catch
                {
                    return Next.Invoke(context);
                }
                
            }

            return Next.Invoke(context);
        }
    }
}
