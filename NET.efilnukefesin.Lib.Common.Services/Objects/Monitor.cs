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

        public IResolution CurrentResolution { get; private set; }  //TODO: think about only storing the current (and therefore preferred) resolution

        public string Name { get; private set; }

        public string PnPDeviceID { get; private set; }

        #endregion Properties

        #region Construction

        public Monitor(string Name, string PnPDeviceID, bool IsPrimary, IResolution CurrentResolution = null)
        {
            this.Name = Name;
            this.PnPDeviceID = PnPDeviceID;
            this.IsPrimary = IsPrimary;
            this.CurrentResolution = CurrentResolution;
        }

        #endregion Construction

        #region Methods

        #region SetPrimary
        public void SetPrimary(bool IsPrimary = true)
        {
            this.IsPrimary = IsPrimary;
        }
        #endregion SetPrimary

        #region SetCurrentResolution
        public void SetCurrentResolution(IResolution Resolution)
        {
            this.CurrentResolution = Resolution;
        }
        #endregion SetCurrentResolution

        #endregion Methods
    }
}
