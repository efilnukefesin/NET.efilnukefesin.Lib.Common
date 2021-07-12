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
        IList<IMessageReceiver> Recipients { get; }

        #endregion Properties

        #region Methods

        void AddReceiver(IMessageReceiver CurrentReceiver);

        #endregion Methods
    }
}
