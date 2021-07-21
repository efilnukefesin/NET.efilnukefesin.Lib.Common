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
        IResolution CurrentResolution { get; }

        #endregion Properties

        #region Methods

        void SetPrimary(bool IsPrimary = true);
        void SetCurrentResolution(IResolution Resolution);

        #endregion Methods
    }
}
