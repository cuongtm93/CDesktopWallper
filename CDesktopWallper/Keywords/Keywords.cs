using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using CDesktopWallper.Extensions;
namespace CDesktopWallper
{
    class Keywords : IKeyword
    {
        private readonly ISettingData _setting;
        public Keywords()
        {
            this._setting = Kernel.Modules.Get<ISettingData>();
        }
        public List<string> GetList()
        {
            return this._setting.Get<List<string>>(Const.Keywords);
        }

        public void Subscribe(string keyword)
        {
            GetList().Add(keyword);
            Save();
        }

        public void UnSubscribe(string keyword)
        {
            GetList().Remove(keyword);
            Save();
        }

        private void Save()
        {
            this._setting.Set(Const.Keywords, GetList().Serialize());
            this._setting.Save();
        }
    }
}
