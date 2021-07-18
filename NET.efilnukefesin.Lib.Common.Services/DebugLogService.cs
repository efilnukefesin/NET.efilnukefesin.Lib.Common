using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class DebugLogService : ILogService
    {
        #region Properties

        private IErrorService errorService;

        public int FatalCount { get; private set; } = 0;

        public int ErrorCount { get; private set; } = 0;

        public int WarningCount { get; private set; } = 0;

        public int InfoCount { get; private set; } = 0;

        public int DebugCount { get; private set; } = 0;

        #endregion Properties

        #region Construction

        public DebugLogService(IErrorService errorService)
        {
            this.errorService = errorService;

        }

        #endregion Construction

        #region Methods

        #region Debug
        public void Debug(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null)
        {
            this.WriteEntry("Debug", SenderClassName, SenderMethodName, Entry, exception);
            this.DebugCount++;
        }
        #endregion Debug

        #region Error
        public void Error(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null)
        {
            this.WriteEntry("Error", SenderClassName, SenderMethodName, Entry, exception);
            this.errorService.ReportError(SenderClassName, SenderMethodName, Entry, exception, false);
            this.ErrorCount++;
        }
        #endregion Error

        #region Fatal
        public void Fatal(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null)
        {
            this.WriteEntry("Fatal", SenderClassName, SenderMethodName, Entry, exception);
            this.errorService.ReportFatal(SenderClassName, SenderMethodName, Entry, exception, true);
            this.FatalCount++;
        }
        #endregion Fatal

        #region Info
        public void Info(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null)
        {
            this.WriteEntry("Info", SenderClassName, SenderMethodName, Entry, exception);
            this.InfoCount++;
        }
        #endregion Info

        #region Warning
        public void Warning(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null)
        {
            this.WriteEntry("Warning", SenderClassName, SenderMethodName, Entry, exception);
            this.WarningCount++;
        }
        #endregion Warning

        #region WriteEntry
        private void WriteEntry(string Severity, string SenderClassName, string SenderMethodName, string Entry, Exception exception)
        {
            //TODO: format Exception and add if not empty
            System.Diagnostics.Debug.WriteLine($"[{Severity}] {SenderClassName}.{SenderMethodName}: {Entry}");
        }
        #endregion WriteEntry

        #endregion Methods
    }
}
