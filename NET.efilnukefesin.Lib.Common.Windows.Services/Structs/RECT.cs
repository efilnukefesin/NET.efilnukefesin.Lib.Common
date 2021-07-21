using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Windows.Services.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
