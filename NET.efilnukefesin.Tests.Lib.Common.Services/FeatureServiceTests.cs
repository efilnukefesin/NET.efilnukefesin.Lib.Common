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
            ITimeService timeService = DiContainer.Resolve<ITimeService>();
            string placeTimeName = "AddTimedFeature";
            timeService.SetCurrentTime(placeTimeName, DateTime.Now);

            this.service.AddTimed("AddTimedFeature", 5000, placeTimeName);
            this.service.AddTimed("AddTimedFeature2", timeService.GetCurrentTime(placeTimeName) + TimeSpan.FromHours(1), placeTimeName);

            Assert.AreEqual(true, this.service.Exists("AddTimedFeature"));
            Assert.AreEqual(true, this.service.Exists("AddTimedFeature2"));
        }
        #endregion AddTimedFeature

        #region AddRandomFeature
        [TestMethod]
        public void AddRandomFeature()
        {
            this.service.AddRandom("AddRandomFeature", 3, 10);

            Assert.AreEqual(true, this.service.Exists("AddRandomFeature"));
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
            ITimeService timeService = DiContainer.Resolve<ITimeService>();
            string placeTimeName = "CheckTimedFeature";
            timeService.SetCurrentTime(placeTimeName, DateTime.Now);

            this.service.AddTimed("CheckTimedFeature", 5000, placeTimeName);
            this.service.AddTimed("CheckTimedFeature2", timeService.GetCurrentTime(placeTimeName) + TimeSpan.FromHours(1), placeTimeName);

            timeService.FastForward(placeTimeName, TimeSpan.FromMinutes(1));

            Assert.AreEqual(true, this.service.Check("CheckTimedFeature"));
            Assert.AreEqual(false, this.service.Check("CheckTimedFeature2"));
        }
        #endregion CheckTimedFeature

        #region CheckRandomFeatureDynamic
        [DataTestMethod]
        [DataRow(1, 1, true)]
        [DataRow(10, 10, true)]
        [DataRow(3, 10, null)]
        public void CheckRandomFeatureDynamic(int Numerator, int Denominator, bool? Assertion)
        {
            this.service.AddRandom("CheckRandomFeatureDynamic", Numerator, Denominator, false);

            Assert.IsInstanceOfType(this.service.Check("CheckRandomFeatureDynamic"), typeof(bool));
            if (Assertion != null)
            {
                Assert.AreEqual((bool)Assertion, this.service.Check("CheckRandomFeatureDynamic"));
            }
        }
        #endregion CheckRandomFeatureDynamic

        #region CheckRandomFeatureStatic
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(10, 10)]
        [DataRow(3, 10)]
        [DataRow(3, 10000)]
        public void CheckRandomFeatureStatic(int Numerator, int Denominator)
        {
            this.service.AddRandom("CheckRandomFeatureStatic", Numerator, Denominator, false);

            bool firstValue = this.service.Check("CheckRandomFeatureDynamic");
            bool secondValue = this.service.Check("CheckRandomFeatureDynamic");

            Assert.IsInstanceOfType(this.service.Check("CheckRandomFeatureStatic"), typeof(bool));
            Assert.AreEqual(firstValue, secondValue);
        }
        #endregion CheckRandomFeatureStatic

        #endregion Methods
    }
}
