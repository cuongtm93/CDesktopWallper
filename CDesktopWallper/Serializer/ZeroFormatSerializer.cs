using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CDesktopWallper
{
    class ZeroFormatSerializer : ISerializer<byte[]>
    {
        public T DeserializeObject<T>(byte[] value)
        {
            throw new NotSupportedException();
        }

        public byte[] LoadFile(string file)
        {
            if (File.Exists(file))
                return File.ReadAllBytes(file);
            else
                return null;
        }

        public void SaveFile(byte[] output, string file)
        {
            File.WriteAllBytes(file, output);
        }

        public  byte[] Serialize<T>(T value)
        {
            throw new NotSupportedException();
        }
    }
}
