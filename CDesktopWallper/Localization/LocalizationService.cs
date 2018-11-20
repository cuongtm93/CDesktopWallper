using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class LocalizationService : ILocalizationService
    {

        public string this[string text]
        {
            get
            {
                return text;
            }
        }

        public void SetLocalization(string locale)
        {
            switch (locale)
            {
                case "vietnam":
                    System.Windows.Forms.MessageBox.Show(locale);
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show("english");
                    break;
            }
        }
    }
}
