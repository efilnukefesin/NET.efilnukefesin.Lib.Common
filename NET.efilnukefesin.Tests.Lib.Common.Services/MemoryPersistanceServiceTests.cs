using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("IPersistanceService")]
    public class MemoryPersistanceServiceTests : BaseServiceTest<IPersistanceService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region AddEndpoint
        [TestMethod]
        public void AddEndpoint()
        {
            bool wasSuccessful = this.service.AddEndpoint("Read", "Read/int");

            Assert.AreEqual(true, wasSuccessful);
            Assert.AreEqual(true, this.service.Exists("Read"));
        }
        #endregion AddEndpoint

        #region AddEndpointNegative
        [TestMethod]
        public void AddEndpointNegative()
        {
            bool wasSuccessful = this.service.AddEndpoint("Read", "Read/int");
            bool wasSuccessful2 = this.service.AddEndpoint("Read", "Read/int");

            Assert.AreEqual(true, wasSuccessful);
            Assert.AreEqual(true, this.service.Exists("Read"));
            Assert.AreEqual(false, wasSuccessful2);
        }
        #endregion AddEndpointNegative

        #region Read
        [TestMethod]
        public void Read()
        {
            int value = 1;
            this.service.AddEndpoint("Read", "Read/int");
            this.service.Write<int>("Read", value);
            int resultValue = this.service.Read<int>("Read");

            Assert.AreEqual(value, resultValue);
        }
        #endregion Read

        #region Write
        [TestMethod]
        public void Write()
        {
            this.service.AddEndpoint("Write", "Write/int");
            this.service.Write<int>("Write", 1);

            Assert.AreEqual(true, this.service.ValueExists("Write"));
        }
        #endregion Write

        #endregion Methods
    }
}
