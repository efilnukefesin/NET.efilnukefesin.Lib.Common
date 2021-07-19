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
    [TestCategory("IConfigurationService")]
    public class ConfigurationServiceTests
    {
        #region Properties

        private IConfigurationService configurationService;

        #endregion Properties

        #region Methods

        #region Initialize
        [TestInitialize]
        public void Initialize()
        {
            TestBootStrapper.Register(new ServiceCollection());

            this.configurationService = DiContainer.Resolve<IConfigurationService>();
        }
        #endregion Initialize

        #endregion Methods
    }
}
