using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class TimeService : ITimeService
    {
        #region Properties

        private ILogService logService;

        private Dictionary<string, DateTime> times;

        #endregion Properties

        #region Construction

        public TimeService(ILogService LogService)
        {
            this.logService = LogService;

            this.times = new Dictionary<string, DateTime>();
        }

        #endregion Construction

        #region Methods

        #region GetCurrentTime
        public DateTime GetCurrentTime(string PlaceName)
        {
            DateTime result = default;

            this.logService.Debug("TimeService", "GetCurrentTime", $"Request for current time at '{PlaceName}'");

            if (this.times.ContainsKey(PlaceName))
            {
                result = this.times[PlaceName];
                this.logService.Debug("TimeService", "GetCurrentTime", $"Found time at '{PlaceName}'.");
            }

            this.logService.Debug("TimeService", "GetCurrentTime", $"Returning '{result}' for '{PlaceName}.'");

            return result;
        }
        #endregion GetCurrentTime

        #region SetCurrentTime
        public void SetCurrentTime(string PlaceName, DateTime NewTime)
        {
            this.logService.Debug("TimeService", "SetCurrentTime", $"Setting current time for '{PlaceName}.'");
            if (this.times.ContainsKey(PlaceName))
            {
                this.times[PlaceName] = NewTime;
                this.logService.Debug("TimeService", "SetCurrentTime", $"Overwritten time for '{PlaceName}.'");
            }
            else
            {
                this.times.Add(PlaceName, NewTime);
                this.logService.Debug("TimeService", "SetCurrentTime", $"created a new entry for '{PlaceName}.'");
            }
        }
        #endregion SetCurrentTime

        #endregion Methods

        #region Events

        #endregion Events
    }
}
