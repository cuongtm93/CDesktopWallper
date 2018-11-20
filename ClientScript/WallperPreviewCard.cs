using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientScript
{
    public class WallperPreviewCard
    {
        public string Title { get; set; }
        public string Status { get; set; }

        public string Wallper { get; set; }
        public string Thumb { get; set; }
        public override string ToString()
        {
            StringBuilder myvar = new StringBuilder();
            if (string.IsNullOrEmpty(this.Thumb))
                this.Thumb = Wallper;


            /// onclick=\"ClientScript.LocalWallperWebViewWSClient.SetWallper(this)\"

            myvar.Append("<div class=\"col-md-4\">")
                 .Append("<div class=\"card\">")
                 .Append("<div class=\"card-header\">")
                 .Append($"<strong class=\"card-title\">{Title}<small><span class=\"badge badge-success float-right mt-1\">{Status}</span></small></strong>")
                 .Append("</div>")
                 .Append("<div class=\"card-body\">")
                 .Append("<p>")
                 .Append("<button type=\"button\" name='SetWallper' class=\"btn btn-outline-primary\" ><i class=\"fa fa-star\"></i>&nbsp; Chọn </button>")
                 .Append("</p>")
                 .Append($"<img src=\"{Thumb}\" data-src=\"{Wallper}\" class=\"lazy img-thumbnail\" alt=\"{Wallper}\">")
                 .Append("</div>")
                 .Append("</div>")
                 .Append("</div>");
            return myvar.ToString();
        }
    }
}
