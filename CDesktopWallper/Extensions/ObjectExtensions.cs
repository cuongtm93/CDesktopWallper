using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Runtime.CompilerServices;

namespace CDesktopWallper.Extensions
{
    public static class ObjectExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Serialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsChanged<T>(this T oldValue, T newValue)
        {
            //&& (oldValue != default)
            return (((dynamic)oldValue != (dynamic)newValue));
        }
    }
}
