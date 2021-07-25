using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services.Classes
{
    internal class TestObject : IBaseObject
    {
        #region Properties

        public string Text { get; private set; }
        private ILogService logService;

        #endregion Properties

        #region Construction

        public TestObject(string Text, ILogService LogService)
        {
            this.Text = Text;
            this.logService = LogService;
        }

        #endregion Construction

        #region Methods

        #endregion Methods

        #region Events

        #endregion Events
    }
}
