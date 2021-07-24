﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("ITimeService")]
    public class TimeServiceTests : BaseServiceTest<ITimeService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region SetCurrentTime
        [TestMethod]
        public void SetCurrentTime()
        {
            DateTime startTime = DateTime.Parse("2021-05-01T07:34:42-5:00", DateTimeFormatInfo.InvariantInfo);

            this.service.SetCurrentTime("NewPlace", startTime);

            Assert.AreEqual(startTime, this.service.GetCurrentTime("NewPlace"));
        }
        #endregion SetCurrentTime

        #endregion Methods
    }
}
