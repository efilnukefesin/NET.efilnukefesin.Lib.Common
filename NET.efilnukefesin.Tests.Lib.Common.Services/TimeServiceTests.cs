using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("ITimeService")]
    public class TimeServiceTests
    {
        #region Properties

        private ITimeService timeService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.timeService = DiContainer.Resolve<ITimeService>();
        }
        #endregion Initialize

        #region SetCurrentTime
        [TestMethod]
        public void SetCurrentTime()
        {
            DateTime startTime = DateTime.Parse("2021-05-01T07:34:42-5:00", DateTimeFormatInfo.InvariantInfo);

            this.timeService.SetCurrentTime("NewPlace", startTime);

            Assert.AreEqual(startTime, this.timeService.GetCurrentTime("NewPlace"));
        }
        #endregion SetCurrentTime

        #endregion Methods
    }
}
