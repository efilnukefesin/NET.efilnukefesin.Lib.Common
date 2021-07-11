using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    public class MessageServiceTests
    {
        #region Properties

        IMessageService messageService;

        #endregion Properties

        #region Methods

        #endregion Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.messageService = DiContainer.Resolve<IMessageService>();
        }
        #endregion Initialize

        [TestMethod]
        public void TestMethod1()
        {
            var x = this.messageService.ToString();
        }
    }
}
