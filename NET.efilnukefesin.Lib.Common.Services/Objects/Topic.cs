using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class Topic : ITopic
    {
        #region Properties

        public string Name { get; private set; }

        public int MessageCount { get; private set; } = 0;

        public IList<IMessageReceiver> Receivers { get; private set; }

        #endregion Properties

        #region Construction
        public Topic(string Name)
        {
            this.Name = Name;
            this.Receivers = new List<IMessageReceiver>();
        }
        #endregion Construction

        #region Methods

        #region CountOneUp
        public void CountOneUp()
        {
            this.MessageCount++;
        }
        #endregion CountOneUp

        #region AddReceiver
        public void AddReceiver(IMessageReceiver Receiver)
        {
            this.Receivers.Add(Receiver);
        }
        #endregion AddReceiver

        #region Publish: Publishes a Message on a Topic
        /// <summary>
        /// Publishes a Message on a Topic
        /// </summary>
        /// <param name="Message">the message to send</param>
        /// <returns>true, if more than zero recipients have been reached</returns>
        public bool Publish(IMessage Message)
        {
            bool result = false;
            this.CountOneUp();

            int counter = 0;
            foreach (IMessageReceiver receiver in this.Receivers)
            {
                receiver.Receive(Message);
                counter++;
            }

            if (counter > 0)
            {
                result = true;
            }

            return result;
        }
        #endregion Publish

        #region RemoveReceiver
        public void RemoveReceiver(IMessageReceiver receiver)
        {
            IMessageReceiver receiverToRemove = this.Receivers.SingleOrDefault(x => x.Id.Equals(receiver.Id));
            this.Receivers.Remove(receiverToRemove);
        }
        #endregion RemoveReceiver

        #endregion Methods
    }
}
