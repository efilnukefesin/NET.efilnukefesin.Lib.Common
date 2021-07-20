using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Objects
{
    public interface IMonitor : IName
    {
        #region Properties

        bool IsPrimary { get; }
        string PnPDeviceID { get; }
        IList<IResolution> Resolutions { get; }

        #endregion Properties

        #region Methods

        void SetPrimary(bool IsPrimary = true);

        #endregion Methods
    }
}
