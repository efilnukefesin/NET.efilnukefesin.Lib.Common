using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class DebugErrorService : IErrorService
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region ReportError
        public void ReportError(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null, bool DoAbortApp = false)
        {
            this.Report("Error", SenderClassName, SenderMethodName, Entry, exception, DoAbortApp);
        }
        #endregion ReportError

        #region ReportFatal
        public void ReportFatal(string SenderClassName, string SenderMethodName, string Entry, Exception exception = null, bool DoAbortApp = true)
        {
            this.Report("Fatal", SenderClassName, SenderMethodName, Entry, exception, DoAbortApp);
        }
        #endregion ReportFatal

        #region Report
        private void Report(string Severity, string SenderClassName, string SenderMethodName, string Entry, Exception exception, bool DoAbortApp)
        {
            //TODO: format Exception and add if not empty
            string abortText = string.Empty;
            if (DoAbortApp)
            {
                abortText = ": App should be aborted";
            }
            System.Diagnostics.Debug.WriteLine($"[{Severity} (ErrorService{abortText})] {SenderClassName}.{SenderMethodName}: {Entry}");
            //TODO: how to abort the app? Send a message? Ring dependency at the end. Use method in IApplicationService?
        }
        #endregion Report

        #endregion Methods
    }
}
