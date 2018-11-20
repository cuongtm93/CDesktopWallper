using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDesktopWallper.Extensions;
using System.IO;
using System.Windows.Forms;

namespace CDesktopWallper
{
    public class Setting : ISetting
    {
        private readonly ILocation _location;
        private readonly ISerializer<string> _serializer;

        public Setting()
        {
            this._location = Kernel.Resolve<ILocation>();
            this._serializer = Kernel.Resolve<ISerializer<string>>();
            this.Data = new SettingData();
        }
        public SettingData Data { get; set; }

        public void Load()
        {
            var value = this._serializer.LoadFile(Const.SettingFile);
            if (value != null)
                this.Data = this._serializer.DeserializeObject<SettingData>(value);
            else
            {
                this.Data = new SettingData();

                InitSomeDefaults();
            }
            
        }

        public void Save()
        {
            this._serializer.SaveFile(this._serializer.Serialize(this.Data), Const.SettingFile);
        }

        private void InitSomeDefaults()
        {
            if (this.Data.WallerSource == default)
                this.Data.WallerSource = nameof(LocalWallperSource);

            //if (this.Data.Locale == default)
            //    this.Data.Locale = this._location.Get().Country.ToLower();

            if (this.Data.AutoWallper == default)
                this.Data.AutoWallper = true;

            Save();
                        
        }
    }
}
