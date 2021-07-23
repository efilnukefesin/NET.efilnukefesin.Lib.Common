using NET.efilnukefesin.Lib.Common.Windows.Services.Interfaces;
using NET.efilnukefesin.Lib.Common.Windows.Services.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using static NET.efilnukefesin.Lib.Common.Windows.Services.Helpers.MonitorHelper;

namespace NET.efilnukefesin.Lib.Common.Windows.Services.Classes
{
    internal class MonitorInfoWithHandle : IMonitorInfoWithHandle
    {
        #region Properties
        /// <summary>
        /// Gets the monitor handle.
        /// </summary>
        /// <value>
        /// The monitor handle.
        /// </value>
        public IntPtr MonitorHandle { get; private set; }

        /// <summary>
        /// Gets the monitor information.
        /// </summary>
        /// <value>
        /// The monitor information.
        /// </value>
        public MONITORINFOEX MonitorInfo { get; private set; }

        #endregion Properties

        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorInfoWithHandle"/> class.
        /// </summary>
        /// <param name="monitorHandle">The monitor handle.</param>
        /// <param name="monitorInfo">The monitor information.</param>
        public MonitorInfoWithHandle(IntPtr monitorHandle, MONITORINFOEX monitorInfo)
        {
            MonitorHandle = monitorHandle;
            MonitorInfo = monitorInfo;
        }
        #endregion Construction
    }
}
