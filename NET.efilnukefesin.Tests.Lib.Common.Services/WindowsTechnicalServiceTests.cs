using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("ITechnicalService")]
    public class WindowsTechnicalServiceTests : BaseServiceTest<ITechnicalService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public override void Initialize()
        {
            //different registration
            TestBootStrapper.RegisterForWindows(new ServiceCollection());

            this.service = DiContainer.Resolve<ITechnicalService>();
        }
        #endregion Initialize

        #region GetComputerName
        [TestMethod]
        public void GetComputerName()
        {
            string computername = this.service.ComputerName;

            Assert.IsNotNull(computername);
            Assert.AreNotEqual(0, computername.Length);
        }
        #endregion GetComputerName

        #region GetOsName
        [TestMethod]
        public void GetOsName()
        {
            string osName = this.service.OperatingSystemName;

            Assert.IsNotNull(osName);
            Assert.AreNotEqual(0, osName.Length);
        }
        #endregion GetOsName

        #region ListMonitors
        [TestMethod]
        public void ListMonitors()
        {
            IList<IMonitor> monitors = this.service.Monitors;

            Assert.AreNotEqual(0, monitors.Count);
        }
        #endregion ListMonitors

        #endregion Methods
    }
}
