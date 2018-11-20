using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    class FileLogWriter : TextWriter
    {
        private readonly FileStream _writer;
        private byte _endofLine = (byte)"\n".ToCharArray()[0];
        public FileLogWriter()
        {
            this._writer = new System.IO.FileStream("log.txt", FileMode.Append);
        }
        public override void Close()
        {
            this._writer.Close();
        }

        public override void Write(char value)
        {
            this._writer.WriteByte((byte)value);
        }
        public override void Write(string value)
        {
            foreach (var _byte in this.Encoding.GetBytes(value.ToCharArray()))
            {
                if (this._writer.CanWrite)
                    this._writer.WriteByte(_byte);
                else
                    throw new AccessViolationException();
            }
            this._writer.WriteByte(this._endofLine);
            this.Flush();
        }
        public override Encoding Encoding => System.Text.Encoding.UTF8;
    }
}
