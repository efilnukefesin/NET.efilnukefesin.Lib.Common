using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Messaging;
using NET.efilnukefesin.Lib.Common.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using NET.efilnukefesin.Tests.Lib.Common.Services.Classes;
using System;
using System.Linq;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("IConfigurationService")]
    public class ConfigurationServiceTests : BaseServiceTest<IConfigurationService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region AddValue
        [TestMethod]
        public void AddValue()
        {
            bool hasAdded = this.service.Add<int>("AddValue", 7);

            Assert.AreEqual(true, this.service.Exists<int>("AddValue"));
            Assert.AreEqual(true, hasAdded);
        }
        #endregion AddValue

        #region AddValueNegative
        [TestMethod]
        public void AddValueNegative()
        {
            bool hasAdded = this.service.Add<int>("AddValueNegative", 7);
            bool hasAdded2 = this.service.Add<int>("AddValueNegative", 8);

            Assert.AreEqual(true, this.service.Exists<int>("AddValueNegative"));
            Assert.AreEqual(true, hasAdded);
            Assert.AreEqual(false, hasAdded2);
        }
        #endregion AddValueNegative

        #region ReadValue
        [TestMethod]
        public void ReadValue()
        {
            this.service.Add<int>("ReadValue", 7);

            Assert.AreEqual(7, this.service.Get<int>("ReadValue"));
        }
        #endregion ReadValue

        #endregion Methods
    }
}
