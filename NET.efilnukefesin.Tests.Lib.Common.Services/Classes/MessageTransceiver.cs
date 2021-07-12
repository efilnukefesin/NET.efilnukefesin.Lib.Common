using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services.Classes
{
    internal class MessageTransceiver : IMessageTransceiver
    {
        #region Properties

        private IMessageService messageService;

        public Guid Id { get; private set; } = Guid.NewGuid();

        #endregion Properties

        #region Methods

        #region Receive
        public bool Receive(IMessage Message)
        {
            bool result = false;
            Message.AddReceiver(this);
            // do stuff based on Message Subject and Content
            return result;
        }
        #endregion Receive

        #region Send
        public bool Send(string TopicName, IMessage Message)
        {
            bool result = false;
            result = this.messageService.Send(this, TopicName, Message);
            return result;
        }
        #endregion Send

        #region SetMessageService
        public void SetMessageService(IMessageService MessageService)
        {
            this.messageService = MessageService;
        }
        #endregion SetMessageService

        #endregion Methods
    }
}
