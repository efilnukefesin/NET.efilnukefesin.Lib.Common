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

        IMessageService messageService;

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

        #region Send
        [TestMethod]
        public void Send()
        {
            string topicName = "NewTopic";
            MessageTransceiver messageTransceiver = DiContainer.Resolve<MessageTransceiver>();
            bool isRegistered = this.messageService.Register(messageTransceiver, topicName);
            messageTransceiver.Send(topicName, new Message("TestSubject", 666, messageTransceiver));

            Assert.AreEqual(true, isRegistered);
            Assert.AreEqual(1, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().MessageCount);
            Assert.AreEqual(1, this.messageService.Topics.Where(x => x.Name.Equals(topicName)).FirstOrDefault().Receivers.Count);
        }
        #endregion Send

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
