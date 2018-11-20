using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper.Frontend
{
    public class WsCommandProc
    {
        public static WsCommand Parse(string s)
        {
            try
            {
                return JsonConvert.DeserializeObject<WsCommand>(s);
            }
            catch
            {
                return new WsCommand();
            }
        }
        public static string ToString(WsCommand cmd)
        {
            return JsonConvert.SerializeObject(cmd);
        }
    }
}
