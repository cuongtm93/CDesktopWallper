using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    public class UrlRewriteMiddleware : OwinMiddleware
    {
        const string @default = "/index.html";
        public UrlRewriteMiddleware(OwinMiddleware next) : base(next)
        {

        }
        public override Task Invoke(IOwinContext context)
        {
            var request = context.Request.Path.Value;
            if (request == "/" || request.EndsWith(".html"))
                context.Request.Path = new PathString(@default);

            return Next.Invoke(context);
        }
    }
}
