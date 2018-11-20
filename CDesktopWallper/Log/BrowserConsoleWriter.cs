
using CDesktopWallper.Frontend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDesktopWallper
{
    public class BrowserConsoleWriter : TextWriter
    {
        private readonly IWsServer wsServer;
        private StringBuilder buffer = new StringBuilder();
        public BrowserConsoleWriter()
        {
            this.wsServer = Kernel.Resolve<IWsServer>();
            Console.SetOut(this);
        }
        public override void Write(char value)
        {
            if (value == '\r')
            {
                this.wsServer.Broadcast(buffer.ToString());
                buffer.Clear();
            }
            else
                buffer.Append(value);

        }
        public override void Write(string value)
        {
            Array.ForEach(value.ToCharArray(), _char => Write(_char));
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }

}
