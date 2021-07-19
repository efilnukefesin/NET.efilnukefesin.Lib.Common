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

        public string OperatingSystemName { get; private set; }

        public IList<IMonitor> Monitors { get; private set; }

        public bool IsInitialized { get; private set; } = false;

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
                this.Monitors = new List<IMonitor>();
                IList<IResolution> resolutions = new List<IResolution>();
                IResolution resolution01 = DiContainer.Resolve<Resolution>(1024, 768);
                resolutions.Add(resolution01);
                IMonitor monitor01 = DiContainer.Resolve<Monitor>("Dummy Monitor", true, resolutions);
                this.Monitors.Add(monitor01);
                
                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #endregion Methods
    }
}
