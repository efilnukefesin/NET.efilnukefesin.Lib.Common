using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using NET.efilnukefesin.Tests.Lib.Common.Services.Classes;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("IObjectService")]
    public class ObjectServiceTests : BaseServiceTest<IObjectService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region Create
        [TestMethod]
        public void Create()
        {
            TestObject testObject = this.service.Create<TestObject>("SomeString");

            Assert.IsNotNull(testObject);
            Assert.IsInstanceOfType(testObject, typeof(TestObject));
            Assert.AreEqual("SomeString", testObject.Text);
        }
        #endregion Create

        #region CreateNegative
        [TestMethod]
        public void CreateNegative()
        {
            ILogService logService = DiContainer.Resolve<ILogService>();

            int numberOfErrorsBefore = logService.ErrorCount;

            TestObject testObject = this.service.Create<TestObject>(666);  // using the wrong parameter for the c'tor

            int numberOfErrorsAfter = logService.ErrorCount;

            Assert.IsNull(testObject);
            Assert.AreEqual(numberOfErrorsBefore + 1, numberOfErrorsAfter);
        }
        #endregion CreateNegative

        #region Count
        [TestMethod]
        public void Count()
        {
            int initialCount = this.service.Count();
            TestObject testObject = this.service.Create<TestObject>("SomeString");
            TestObject testObject2 = this.service.Create<TestObject>("SomeOtherString");
            int lastCount = this.service.Count();

            Assert.AreEqual(2, lastCount - initialCount);
        }
        #endregion Count

        #endregion Methods
    }
}
