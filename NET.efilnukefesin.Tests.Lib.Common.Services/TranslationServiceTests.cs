using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("ITranslationService")]
    public class TranslationServiceTests : BaseServiceTest<ITranslationService>
    {
        #region Methods

        #region Add
        [TestMethod]
        public void Add()
        {
            int numberBefore = this.service.GetNumberOfTranslations("DE-de");
            this.service.Add("DE-de", "Add", "Das war ein Fehler!");
            this.service.Add("EN-en", "Add", "This was an error!");
            int numberAfter = this.service.GetNumberOfTranslations("DE-de");

            Assert.AreEqual(1, numberAfter - numberBefore);
            Assert.AreEqual(2, this.service.GetNumberOfLanguagesFor("Add"));
        }
        #endregion Add

        #region Get
        [TestMethod]
        public void Get()
        {
            this.service.Add("DE-de", "Get", "This was an error!");

            string result = this.service.Get("DE-de", "Get");

            Assert.AreEqual("This was an error!", result);
        }
        #endregion Get

        #region GetWithParams
        [TestMethod]
        public void GetWithParams()
        {
            this.service.Add("DE-de", "GetWithParams", "This was an error with comments '{0}'!");

            string result = this.service.Get("DE-de", "GetWithParams", 123);

            Assert.AreEqual("This was an error with comments '123'!", result);
        }
        #endregion GetWithParams

        #endregion Methods
    }
}
