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
        private static List<IMonitorInfoWithHandle> _monitorInfos = new List<IMonitorInfoWithHandle>();

        #endregion Properties

        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        #region Imported Methods
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hmon, ref MONITORINFO mi);
        #endregion Imported Methods

        #region Methods

        public static bool MonitorEnum(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
        {
            var mi = new MONITORINFO();
            mi.size = (uint)Marshal.SizeOf(mi);
            MonitorHelper.GetMonitorInfo(hMonitor, ref mi);

            // Add to monitor info
            _monitorInfos.Add(new MonitorInfoWithHandle(hMonitor, mi));
            return true;
        }

        public static List<IMonitorInfoWithHandle> GetHandles()
        {
            return MonitorHelper._monitorInfos;
        }

        #endregion Methods

        //https://xcalibursystems.com/accessing-monitor-information-with-c-part-1-getting-monitor-handles/
    }
}
