﻿using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
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

        private string Placename;

        #endregion Properties

        #region Construction

        public TimedFeature(string Name, DateTime SwitchPoint, ITimeService TimeService, string Placename)
            : base(Name)
        {
            this.timeService = TimeService;
            this.SwitchPoint = SwitchPoint;
            this.Placename = Placename;
        }

        public TimedFeature(string Name, int MilliSecondsFromNow, ITimeService TimeService, string Placename)
            : base(Name)
        {
            this.timeService = TimeService;
            this.SwitchPoint = this.timeService.GetCurrentTime(Placename) + TimeSpan.FromMilliseconds(MilliSecondsFromNow);
            this.Placename = Placename;
        }

        #endregion Construction

        #region Methods

        #region Check
        public override bool Check()
        {
            bool result = false;

            if (this.timeService.GetCurrentTime(this.Placename) >= this.SwitchPoint)
            {
                result = true;
            }

            return result;
        }
        #endregion Check

        #endregion Methods
    }
}
