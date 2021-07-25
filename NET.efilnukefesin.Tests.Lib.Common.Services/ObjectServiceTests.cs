using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Create()
        {
            TestObject testObject = this.service.Create<TestObject>("SomeString");

            Assert.IsNotNull(testObject);
            Assert.IsInstanceOfType(testObject, typeof(TestObject));
            Assert.AreEqual("SomeString", testObject.Text);
        }

        #endregion Methods
    }
}
