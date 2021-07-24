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
    [TestCategory("IFeatureService")]
    public class FeatureServiceTests : BaseServiceTest<IFeatureService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region AddStaticFeature
        [TestMethod]
        public void AddStaticFeature()
        {
            this.service.AddStatic("AddStaticFeature");

            Assert.AreEqual(true, this.service.Exists("AddStaticFeature"));
        }
        #endregion AddStaticFeature

        #region AddTimedFeature
        [TestMethod]
        public void AddTimedFeature()
        {
            throw new NotImplementedException();
        }
        #endregion AddTimedFeature

        #region AddRandomFeature
        [TestMethod]
        public void AddRandomFeature()
        {
            throw new NotImplementedException();
        }
        #endregion AddRandomFeature

        #region CheckStaticFeature
        [TestMethod]
        public void CheckStaticFeature()
        {
            this.service.AddStatic("CheckStaticFeature");

            Assert.AreEqual(true, this.service.Check("CheckStaticFeature"));
        }
        #endregion CheckStaticFeature

        #region CheckTimedFeature
        [TestMethod]
        public void CheckTimedFeature()
        {
            throw new NotImplementedException();
        }
        #endregion CheckTimedFeature

        #region CheckRandomFeature
        [TestMethod]
        public void CheckRandomFeature()
        {
            throw new NotImplementedException();
        }
        #endregion CheckRandomFeature        

        #endregion Methods
    }
}
