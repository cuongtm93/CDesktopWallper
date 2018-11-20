using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface ISerializer<TOutput>
    {
        T DeserializeObject<T>(TOutput value);
        TOutput Serialize<T>(T value);

        TOutput LoadFile(string file);

        void SaveFile(TOutput output, string file);
    }
}
