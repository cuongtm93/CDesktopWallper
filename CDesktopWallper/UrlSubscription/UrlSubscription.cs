using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    public class UrlSubscription : IUrlSubscription
    {
        private readonly ISetting _setting;
        public UrlSubscription()
        {
            this._setting = Kernel.Modules.Get<ISetting>();
        }
        public List<string> GetList()
        {
            return this._setting.Get<List<string>>(Const.UrlSubscription);
        }

        public void Subscribe(string url)
        {
            var List = GetList();
            List.Add(url);
            SaveSetting(List);
        }

        public void UnSubscribe(string url)
        {
            var List = GetList();
            List.Remove(url);
            SaveSetting(List);
        }
        private void SaveSetting(List<string> List)
        {
            this._setting.Set(Const.UrlSubscription, List.Serialize());
            this._setting.Save();
        }
    }
}
