using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Objects
{
    public interface IMessageReceiver : IId
    {
        #region Properties

        #endregion Properties

        #region Methods

        bool Receive(IMessage Message);
        void SetMessageService(IMessageService MessageService);

        #endregion Methods
    }
}
