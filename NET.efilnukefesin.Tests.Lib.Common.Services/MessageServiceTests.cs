using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    public class MessageServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IMessageService messageService = new MessageService();
        }
    }
}
