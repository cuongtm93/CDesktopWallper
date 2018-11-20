using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IUrlSubscription
    {
        void Subscribe(string url);

        void UnSubscribe(string url);

        List<string> GetList();
    }
}
