using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;

namespace CDesktopWallper.Frontend
{

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<UrlRewriteMiddleware>();
            app.Use<ReponseContentTypeMiddleware>();
            app.Use<BrowserCacheMiddleWare>();
            app.Use<MemCacheMiddleware>();
            app.Use<ContentWriterMiddleware>();

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnsureInitialized();

            app.UseWebApi(config);
        }
    }
}
