using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientScript
{
    public class WallperPage : List<WallperPreviewCard>
    {

        public override string ToString()
        {
            var s = new StringBuilder();
            foreach (var item in this)
            {
                s.Append(item.ToString());
            }
            return s.ToString();
        }
    }
}
