using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Objects
{
    public interface IMessage
    {
        #region Properties

        string Subject { get; }
        object Payload { get; }
        IMessageSender Sender { get; }
        IEnumerable<IMessageReceiver> Recipients { get; }

        #endregion Properties

        #region Methods

        #endregion Methods
    }
}
