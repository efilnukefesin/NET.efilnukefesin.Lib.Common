using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Logging")]
    public interface ILogService : IService
    {
        #region Properties

        int FatalCount { get; }
        int ErrorCount { get; }
        int WarningCount { get; }
        int InfoCount { get; }
        int DebugCount { get; }

        #endregion Properties

        #region Methods

        void Fatal(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null);
        void Error(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null);
        void Warning(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null);
        void Info(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null);
        void Debug(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null);

        #endregion Methods
    }
}
