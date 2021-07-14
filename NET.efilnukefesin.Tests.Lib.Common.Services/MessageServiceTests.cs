using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Messaging;
using NET.efilnukefesin.Lib.Common.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using NET.efilnukefesin.Tests.Lib.Common.Services.Classes;
using System.Linq;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    public class MessageServiceTests
    {
        #region Properties

        private IMessageService messageService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.messageService = DiContainer.Resolve<IMessageService>();
        }
        #endregion Initialize

        #region Register
        [TestMethod]
        public void Register()
        {
            string topicName = "NewTopic";
            MessageTransceiver messageTransceiver = DiContainer.Resolve<MessageTransceiver>();
            bool isRegistered = this.messageService.Register(messageTransceiver, topicName);

            Assert.AreEqual(true, isRegistered);
            Assert.AreEqual(1, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().Receivers.Count);
        }
        #endregion Register

        #region SendToOneRecipient
        [TestMethod]
        public void SendToOneRecipient()
        {
            string topicName = "NewTopic";
            MessageTransceiver messageTransceiver = DiContainer.Resolve<MessageTransceiver>();
            bool isRegistered = this.messageService.Register(messageTransceiver, topicName);
            messageTransceiver.Send(topicName, new Message("TestSubject", 666, messageTransceiver));

            Assert.AreEqual(true, isRegistered);
            Assert.AreEqual(1, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().MessageCount);
            Assert.AreEqual(1, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().Receivers.Count);
            Assert.AreEqual(true, messageTransceiver.HasReceivedMessage);
        }
        #endregion SendToOneRecipient

        #region SendToTwoRecipients
        [TestMethod]
        public void SendToTwoRecipients()
        {
            string topicName = "NewTopic";
            MessageTransceiver messageTransceiver1 = DiContainer.Resolve<MessageTransceiver>();
            MessageTransceiver messageTransceiver2 = DiContainer.Resolve<MessageTransceiver>();
            bool isRegistered1 = this.messageService.Register(messageTransceiver1, topicName);
            bool isRegistered2 = this.messageService.Register(messageTransceiver2, topicName);
            messageTransceiver1.Send(topicName, new Message("TestSubject", 666, messageTransceiver1));

            Assert.AreEqual(true, isRegistered1);
            Assert.AreEqual(true, isRegistered2);
            Assert.AreEqual(1, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().MessageCount);
            Assert.AreEqual(2, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().Receivers.Count);
            Assert.AreEqual(true, messageTransceiver1.HasReceivedMessage);
            Assert.AreEqual(true, messageTransceiver2.HasReceivedMessage);
        }
        #endregion SendToTwoRecipients

        #region Deregister
        [TestMethod]
        public void Deregister()
        {
            string topicName = "NewTopic";
            MessageTransceiver messageTransceiver = DiContainer.Resolve<MessageTransceiver>();
            bool isRegistered = this.messageService.Register(messageTransceiver, topicName);
            bool isDeregistered = this.messageService.Deregister(messageTransceiver, topicName);

            Assert.AreEqual(true, isRegistered);
            Assert.AreEqual(0, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().Receivers.Count);
            Assert.AreEqual(true, isDeregistered);
        }
        #endregion Deregister

        #endregion Methods
    }
}
