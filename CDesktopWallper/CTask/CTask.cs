using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDesktopWallper
{
    public class CTask : ICTask
    {
        public Timer Clock { get; set; }

        public CTask()
        {
            this.Clock = new Timer();
            this.Trigger();
            this.Clock.Tick += this.Clock_Tick;
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            Task.Run(() =>
             {
                 this.Clock.Stop();
                 this.Action();
             }).GetAwaiter().OnCompleted(() =>
             {
                 this.Clock.Start();
             });
        }

        public virtual void Action()
        {
            throw new NotImplementedException();
        }

        public virtual void Trigger()
        {
            throw new NotImplementedException();
        }
        public void Pause()
        {
            this.Clock.Enabled = false;
        }

        public void Start()
        {
            this.Clock.Start();

            // trigger event the first time
            Action();
        }

        public void Stop()
        {
            this.Clock.Stop();
        }

        ~CTask()
        {
            this.Clock.Dispose();
        }
    }
}
