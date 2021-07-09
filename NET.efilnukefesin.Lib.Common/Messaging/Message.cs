using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Messaging
{
    public class Message : IMessage
    {
        #region Properties

        public string Subject { get; private set; }

        public object Payload { get; private set; }

        public IMessageSender Sender { get; private set; }

        public IEnumerable<IMessageReceiver> Recipients { get; private set; }

        #endregion Properties

        #region Construction

        #endregion Construction

        #region Methods

        #endregion Methods
    }
}
