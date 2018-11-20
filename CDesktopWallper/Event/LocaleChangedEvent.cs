using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public class LocaleChangedEvent
    {
        public LocaleChangedEvent(string locale)
        {
            this.Locale = locale;
        }
        public string Locale { get; set; }
    }
}
