using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDesktopWallper
{
    public interface ICTaskBase
    {
        Timer Clock { get; set; }
        void Pause();
        void Start();

        void Stop();
    }

    public interface ICTaskImplement
    {
        void Trigger();
        void Action();
    }

    public interface ICTask : ICTaskBase, ICTaskImplement
    {

    }
}
