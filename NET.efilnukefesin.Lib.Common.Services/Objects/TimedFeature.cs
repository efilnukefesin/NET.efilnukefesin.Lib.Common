using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class TimedFeature : BaseFeature
    {
        #region Properties

        private DateTime SwitchPoint;

        private ITimeService timeService;

        #endregion Properties

        #region Construction

        public TimedFeature(string Name, DateTime SwitchPoint, ITimeService TimeService)
            : base(Name)
        {
            this.timeService = TimeService;
            this.SwitchPoint = SwitchPoint;
        }

        public TimedFeature(string Name, int MilliSecondsFromNow, ITimeService TimeService)
            : base(Name)
        {
            this.timeService = TimeService;
            //this.SwitchPoint = SwitchPoint;
        }

        #endregion Construction

        #region Methods

        #region Check
        public override bool Check()
        {
            throw new NotImplementedException();
        }
        #endregion Check

        #endregion Methods
    }
}
