using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("ITechnicalService")]
    public class WindowsTechnicalServiceTests
    {
        #region Properties

        private ITechnicalService technicalService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.RegisterForWindows(new ServiceCollection());

            this.technicalService = DiContainer.Resolve<ITechnicalService>();

            this.technicalService.Initialize();
        }
        #endregion Initialize

        #region ListMonitors
        [TestMethod]
        public void ListMonitors()
        {
            IList<IMonitor> monitors = this.technicalService.Monitors;

            Assert.AreEqual(1, monitors.Count);
        }
        #endregion ListMonitors

        #endregion Methods
    }
}
