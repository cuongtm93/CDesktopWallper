using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    class ReponseContentTypeMiddleware : OwinMiddleware
    {
        public ReponseContentTypeMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public override Task Invoke(IOwinContext context)
        {
            var request = context.Request.Path.Value;
            var MIME = new Dictionary<string, string>()
            {
                [".html"] = "text/html",
                [".css"] = "text/css",
                [".png"] = "image/jpeg",
                [".jpg"] = "image/jpeg",
                [".jpeg"] = "image/jpeg"
            };
            foreach (var type in MIME.Keys)
            {
                if(request.EndsWith(type))
                {
                    context.Response.ContentType = MIME[type];
                    return Next.Invoke(context);
                }
            }            
            return Next.Invoke(context);
        }
    }
}
