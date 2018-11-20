using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientScript
{
    public class Component
    {
        public static async Task<string> GET(string name)
        {
            var url = Resource.Instance.ComponentUrl(name);
            var ajax = new Kernel.AjaxTask()
            {
                Method = Kernel.Http.HttpMethod.GET,
                Url = url,
                Async = true
            };

            return await ajax.Execute();
        }
    }
}
