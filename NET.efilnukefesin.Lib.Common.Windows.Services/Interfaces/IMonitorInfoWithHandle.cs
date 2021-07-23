using NET.efilnukefesin.Lib.Common.Windows.Services.Structs;
using System;
using System.Collections.Generic;
using System.Text;
using static NET.efilnukefesin.Lib.Common.Windows.Services.Helpers.MonitorHelper;

namespace NET.efilnukefesin.Lib.Common.Windows.Services.Interfaces
{
    public interface IMonitorInfoWithHandle
    {
        #region Properties

        IntPtr MonitorHandle { get; }
        MONITORINFOEX MonitorInfo { get; }

        #endregion Properties
    }
}
