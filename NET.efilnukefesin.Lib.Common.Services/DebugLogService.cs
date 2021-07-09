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

        #endregion Properties

        #region Construction

        public DebugLogService(IErrorService errorService)
        {
            this.errorService = errorService;

        }

        #endregion Construction

        #region Methods

        #region Debug
        public void Debug()
        {
            this.WriteEntry();
        }
        #endregion Debug

        #region Error
        public void Error()
        {
            this.WriteEntry();
        }
        #endregion Error

        #region Fatal
        public void Fatal()
        {
            this.WriteEntry();
        }
        #endregion Fatal

        #region Info
        public void Info()
        {
            this.WriteEntry();
        }
        #endregion Info

        #region Warning
        public void Warning()
        {
            this.WriteEntry();
        }
        #endregion Warning

        #region WriteEntry
        private void WriteEntry()
        {
            throw new NotImplementedException();
        }
        #endregion WriteEntry

        #endregion Methods
    }
}
