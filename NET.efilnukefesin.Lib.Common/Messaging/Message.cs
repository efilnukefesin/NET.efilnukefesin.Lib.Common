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

        public IList<IMessageReceiver> Recipients { get; private set; }

        #endregion Properties

        #region Construction

        public Message(string Subject, object Payload, IMessageSender Sender)
        {
            this.Subject = Subject;
            this.Payload = Payload;
            this.Sender = Sender;

            this.Recipients = new List<IMessageReceiver>();
        }

        #endregion Construction

        #region Methods

        #region AddReceiver
        public void AddReceiver(IMessageReceiver CurrentReceiver)
        {
            this.Recipients.Add(CurrentReceiver);
        }
        #endregion AddReceiver

        #endregion Methods
    }
}
