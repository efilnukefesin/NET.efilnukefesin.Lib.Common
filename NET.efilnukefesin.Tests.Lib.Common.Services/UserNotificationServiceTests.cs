using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.efilnukefesin.Lib.Common;
using NET.efilnukefesin.Lib.Common.Interfaces.EventArgs;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services.Objects;
using NET.efilnukefesin.Tests.Lib.Common.Services.Base;
using NET.efilnukefesin.Tests.Lib.Common.Services.BootStrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Tests.Lib.Common.Services
{
    [TestClass]
    [TestCategory("IUserNotificationService")]
    public class UserNotificationServiceTests : BaseServiceTest<IUserNotificationService>
    {
        #region Properties

        #endregion Properties

        #region Methods

        #region Enqueue
        [TestMethod]
        public void Enqueue()
        {
            List<IUserNotification> notifications = new List<IUserNotification>();

            this.service.OnNewNotification += delegate (object sender, UserNotificationRaisedEventArgs e)
            {
                notifications.Add(e.UserNotification);
            };

            this.service.Enqueue(new UserNotification("TestNotification", "this is a helpful text to guide the user into solving the issue"));

            Assert.AreEqual(1, notifications.Count);
        }
        #endregion Enqueue

        #region EnqueueNegative
        [TestMethod]
        public void EnqueueNegative()
        {
            ILogService logService = DiContainer.Resolve<ILogService>();

            this.service.Enqueue(new UserNotification("TestNotification", "this is a helpful text to guide the user into solving the issue"));

            Assert.AreEqual(1, logService.WarningCount);
        }
        #endregion EnqueueNegative

        #endregion Methods
    }
}
