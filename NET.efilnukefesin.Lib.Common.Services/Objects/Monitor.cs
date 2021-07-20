using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class Monitor : IMonitor
    {
        #region Properties

        public bool IsPrimary { get; private set; }

        public IList<IResolution> Resolutions { get; private set; }

        public string Name { get; private set; }

        public string PnPDeviceID { get; private set; }

        #endregion Properties

        #region Construction

        public Monitor(string Name, string PnPDeviceID, bool IsPrimary, IList<IResolution> Resolutions)
        {
            this.Name = Name;
            this.PnPDeviceID = PnPDeviceID;
            this.IsPrimary = IsPrimary;
            this.Resolutions = Resolutions;
        }

        #endregion Construction

        #region Methods

        #region SetPrimary
        public void SetPrimary(bool IsPrimary = true)
        {
            this.IsPrimary = IsPrimary;
        }
        #endregion SetPrimary

        #endregion Methods
    }
}
