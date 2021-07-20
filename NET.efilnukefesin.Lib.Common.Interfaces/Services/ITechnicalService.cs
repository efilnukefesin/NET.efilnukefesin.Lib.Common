using NET.efilnukefesin.Lib.Common.Attributes;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Application Control")]
    public interface ITechnicalService : IInitialize
    {
        #region Properties

        string OperatingSystemName { get; }
        string ComputerName { get; }

        IList<IMonitor> Monitors { get; }

        #endregion Properties

        #region Methods

        #endregion Methods
    }
}
