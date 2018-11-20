using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public class Scalar
    {
        public static int MiliSecond => 1;

        public static int Second => 1000 * MiliSecond;
        public static int Minute => 60 * Second;

        public static int Hour => 60 * Minute;

        public static int Day => 24 * Hour;

        public static int Month => 30 * Day;
    }
}
