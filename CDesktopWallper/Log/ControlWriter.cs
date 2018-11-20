
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
    public class ControlWriter : TextWriter
    {
        private readonly Control _textbox;
        public ControlWriter(Control textbox)
        {
            this._textbox = textbox;
        }

        public override void Write(char value)
        {
            if (!this._textbox.InvokeRequired)
                this._textbox.Text += value;
        }

        public override void Write(string value)
        {
            if (!this._textbox.InvokeRequired)
                this._textbox.Text += value;
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }

}
