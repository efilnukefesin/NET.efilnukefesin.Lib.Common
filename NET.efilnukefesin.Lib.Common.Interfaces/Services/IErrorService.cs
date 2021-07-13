using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Logging")]
    public interface IErrorService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        void ReportError(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null, bool DoAbortApp = false);
        void ReportFatal(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null, bool DoAbortApp = true);

        #endregion Methods
    }
}
