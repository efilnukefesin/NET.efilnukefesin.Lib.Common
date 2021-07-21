using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class TechnicalService : ITechnicalService
    {
        #region Properties

        public bool IsInitialized { get; private set; } = false;

        public string OperatingSystemName { get; private set; }

        public string ComputerName { get; private set; }

        public IList<IMonitor> Monitors { get; private set; }

        #endregion Properties

        #region Construction

        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                this.OperatingSystemName = "Dummy OS";
                this.ComputerName = "Some Computer";
                this.Monitors = new List<IMonitor>();
                IResolution resolution01 = DiContainer.Resolve<Resolution>(1024, 768);
                IMonitor monitor01 = DiContainer.Resolve<Monitor>("PnP Device Name", "Dummy Monitor", true, resolution01);
                this.Monitors.Add(monitor01);
                
                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #endregion Methods
    }
}
