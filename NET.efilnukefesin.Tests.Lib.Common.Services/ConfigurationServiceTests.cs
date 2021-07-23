using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Messaging;
using NET.efilnukefesin.Lib.Common.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using NET.efilnukefesin.Tests.Lib.Common.Services.Classes;
using System;
using System.Linq;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("IConfigurationService")]
    public class ConfigurationServiceTests
    {
        #region Properties

        private IConfigurationService configurationService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.configurationService = DiContainer.Resolve<IConfigurationService>();
        }
        #endregion Initialize

        #region AddValue
        [TestMethod]
        public void AddValue()
        {
            bool hasAdded = this.configurationService.Add<int>("AddValue", 7);

            Assert.AreEqual(true, this.configurationService.Exists<int>("AddValue"));
            Assert.AreEqual(true, hasAdded);
        }
        #endregion AddValue

        #region AddValueNegative
        [TestMethod]
        public void AddValueNegative()
        {
            bool hasAdded = this.configurationService.Add<int>("AddValueNegative", 7);
            bool hasAdded2 = this.configurationService.Add<int>("AddValueNegative", 8);

            Assert.AreEqual(true, this.configurationService.Exists<int>("AddValueNegative"));
            Assert.AreEqual(true, hasAdded);
            Assert.AreEqual(false, hasAdded2);
        }
        #endregion AddValueNegative

        #region ReadValue
        [TestMethod]
        public void ReadValue()
        {
            this.configurationService.Add<int>("ReadValue", 7);

            Assert.AreEqual(7, this.configurationService.Get<int>("ReadValue"));
        }
        #endregion ReadValue

        #endregion Methods
    }
}
