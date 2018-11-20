using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CDesktopWallper.Frontend
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [Route("getcustomer")]
        public List<string> getcustomer()
        {
            return new List<string> { "avc", "value2" };
        }
    }
}
