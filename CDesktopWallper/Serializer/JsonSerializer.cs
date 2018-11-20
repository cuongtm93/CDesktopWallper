using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CDesktopWallper
{
    class JsonSerializer : ISerializer<string>
    {
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string LoadFile(string file)
        {
            if (File.Exists(file))
                return File.ReadAllText(file);
            else
                return null;
        }

        public void SaveFile(string value, string file)
        {
            try
            {
                File.WriteAllText(file, value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
