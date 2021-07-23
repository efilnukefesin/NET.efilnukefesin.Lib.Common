using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("IPersistanceService")]
    public class PersistanceServiceTests
    {
        #region Properties

        private IPersistanceService persistanceService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.persistanceService = DiContainer.Resolve<IPersistanceService>();
        }
        #endregion Initialize

        #region Read
        [TestMethod]
        public void Read()
        {
            throw new NotImplementedException();
        }
        #endregion Read

        #region Write
        [TestMethod]
        public void Write()
        {
            throw new NotImplementedException();
        }
        #endregion Write

        #endregion Methods
    }
}
