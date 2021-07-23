using NET.efilnukefesin.Lib.Common.Windows.Services.Classes;
using NET.efilnukefesin.Lib.Common.Windows.Services.Interfaces;
using NET.efilnukefesin.Lib.Common.Windows.Services.Structs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Windows.Services.Helpers
{
    public static class MonitorHelper
    {
        #region Properties

        private static List<IMonitorInfoWithHandle> monitorInfos = new List<IMonitorInfoWithHandle>();

        #endregion Properties

        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        #region Imported Methods
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hmon, ref MONITORINFOEX mi);
        #endregion Imported Methods

        #region Methods

        #region MonitorEnum
        public static bool MonitorEnum(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
        {
            MONITORINFOEX mi = new MONITORINFOEX();
            mi.size = (uint)Marshal.SizeOf(mi);
            MonitorHelper.GetMonitorInfo(hMonitor, ref mi);

            // Add to monitor info
            monitorInfos.Add(new MonitorInfoWithHandle(hMonitor, mi));
            return true;
        }
        #endregion MonitorEnum

        #region GetHandles
        public static List<IMonitorInfoWithHandle> GetHandles()
        {
            // Enumerate monitors
            MonitorHelper.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorHelper.MonitorEnum, IntPtr.Zero);
            return MonitorHelper.monitorInfos;
        }
        #endregion GetHandles

        #endregion Methods

        //https://xcalibursystems.com/accessing-monitor-information-with-c-part-1-getting-monitor-handles/
    }
}
