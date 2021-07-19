﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Models;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Messaging;
using NET.efilnukefesin.Lib.Common.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using NET.efilnukefesin.Tests.Lib.Common.Services.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("ITechnicalService")]
    public class TechnicalServiceTests
    {
        #region Properties

        private ITechnicalService technicalService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.technicalService = DiContainer.Resolve<ITechnicalService>();

            this.technicalService.Initialize();
        }
        #endregion Initialize

        #region ListMonitors
        [TestMethod]
        public void ListMonitors()
        {
            IList<IMonitor> monitors = this.technicalService.Monitors;

            Assert.AreEqual(1, monitors.Count);
        }
        #endregion ListMonitors

        #endregion Methods
    }
}
