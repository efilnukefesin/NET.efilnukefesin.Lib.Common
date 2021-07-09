using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class MessageService : IMessageService
    {
        #region Properties

        private ILogService logService;

        #endregion Properties

        #region Construction

        public MessageService(ILogService logService)
        {
            this.logService = logService;
        }

        #endregion Construction

        #region Methods

        #endregion Methods

        #region Events

        #endregion Events

    }
}
