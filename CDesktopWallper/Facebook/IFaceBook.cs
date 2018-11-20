using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IFaceBook
    {
        string AccessToken { get; set; }

        FacebookJson.FbPostResultSuccess PostStatus(string message);
    }
}
