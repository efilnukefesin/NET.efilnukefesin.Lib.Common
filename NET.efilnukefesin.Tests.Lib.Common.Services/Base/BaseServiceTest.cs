using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services.Base
{
    [TestClass]
    public abstract class BaseServiceTest<T> where T: IService
    {
        #region Properties

        protected T service;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public virtual void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.service = DiContainer.Resolve<T>();
        }
        #endregion Initialize

        #endregion Methods
    }
}
