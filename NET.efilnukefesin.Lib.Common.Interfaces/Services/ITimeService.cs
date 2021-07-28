using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Application Control")]
    public interface ITimeService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        DateTime GetCurrentTime(string PlaceName);
        void SetCurrentTime(string PlaceName, DateTime NewTime);
        bool FastForward(string PlaceName, TimeSpan DeltaTime);

        #endregion Methods
    }
}
