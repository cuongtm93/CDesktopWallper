﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDesktopWallper
{
    public interface IApplicationHooking
    {
        void Start();
        void Stop();
    }
}
