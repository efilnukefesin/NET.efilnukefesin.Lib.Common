using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Objects
{
    public interface ITopic : IName
    {
        #region Properties

        int MessageCount { get; }

        IList<IMessageReceiver> Receivers { get; }

        #endregion Properties

        #region Methods

        void CountOneUp();
        void AddReceiver(IMessageReceiver Receiver);
        bool Publish(IMessage Message);
        void RemoveReceiver(IMessageReceiver receiver);

        #endregion Methods
    }
}
