using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Windows.Services.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MONITORINFO
    {
        public uint size;
        public RECT monitor;
        public RECT work;
        public uint flags;
    }
}
