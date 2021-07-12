using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class MessageService : IMessageService
    {
        #region Properties

        private ILogService logService;

        public IList<ITopic> Topics { get; private set; }

        #endregion Properties

        #region Construction

        public MessageService(ILogService logService)
        {
            this.logService = logService;

            this.Topics = new List<ITopic>();
        }
        #endregion Construction

        #region Methods

        #region CreateTopicIfNotExists
        private void CreateTopicIfNotExists(string TopicName)
        {
            if (!this.Topics.Any(x => x.Name.Equals(TopicName)))
            {
                // create new Topic
                Topic newTopic = new Topic(TopicName);
                this.Topics.Add(newTopic);
                this.logService.Info(this.GetType().Name, "CreateTopicIfNotExists", $"Added a new Topic '{TopicName}'");
            }
            else
            {
                this.logService.Debug(this.GetType().Name, "CreateTopicIfNotExists", $"Added no new Topic '{TopicName}' as it already exists");
            }
        }
        #endregion CreateTopicIfNotExists

        #region Register
        public bool Register(IMessageReceiver Receiver, string TopicName)
        {
            bool result = false;
            Receiver.SetMessageService(this);
            this.CreateTopicIfNotExists(TopicName);
            if (this.Topics.Any(x => x.Name.Equals(TopicName)))
            {
                //add to topic
                ITopic existingTopic = this.Topics.Where(x => x.Name.Equals(TopicName)).FirstOrDefault();
                existingTopic.AddReceiver(Receiver);
                this.logService.Info(this.GetType().Name, "Register", $"Added a new Receiver to Topic '{TopicName}'");
                result = true;
            }

            return result;
        }
        #endregion Register

        #region Deregister
        public bool Deregister(IMessageReceiver Receiver, string TopicName)
        {
            bool result = false;
            Receiver.SetMessageService(this);
            this.CreateTopicIfNotExists(TopicName);
            if (this.Topics.Any(x => x.Name.Equals(TopicName)))
            {
                //remove from topic
                ITopic existingTopic = this.Topics.Where(x => x.Name.Equals(TopicName)).FirstOrDefault();
                existingTopic.RemoveReceiver(Receiver);
                this.logService.Info(this.GetType().Name, "Deregister", $"Removed a Receiver from Topic '{TopicName}'");
                result = true;
            }

            return result;
        }
        #endregion Deregister

        #region Send
        public bool Send(IMessageSender Sender, string TopicName, IMessage Message)
        {
            bool result = false;
            this.CreateTopicIfNotExists(TopicName);
            ITopic existingTopic = this.Topics.Where(x => x.Name.Equals(TopicName)).FirstOrDefault();
            result = existingTopic.Publish(Message);
            return result;
        }
        #endregion Send

        //TODO: collect unsent messages and revisit

        #endregion Methods

        #region Events

        #endregion Events
    }
}
