using NET.efilnukefesin.Lib.Common.Attributes;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Messaging")]
    public interface IMessageService : IService 
    {
        #region Properties

        IList<ITopic> Topics { get; }

        #endregion Properties

        #region Methods

        bool Register(IMessageReceiver Receiver, string TopicName);
        bool Deregister(IMessageReceiver Receiver, string TopicName);
        bool Send(IMessageSender Sender, string TopicName, IMessage Message);

        #endregion Methods
    }
}
