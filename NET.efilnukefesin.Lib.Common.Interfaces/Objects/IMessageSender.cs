using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Objects
{
    public interface IMessageSender
    {
        #region Properties

        #endregion Properties

        #region Methods

        bool Send(string TopicName, IMessage Message);

        #endregion Methods
    }
}
