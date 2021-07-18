using NET.efilnukefesin.Lib.Common.Attributes;
using NET.efilnukefesin.Lib.Common.Interfaces.EventArgs;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Messaging")]
    public interface IUserNotificationService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        void Enqueue(IUserNotification Notification);

        #endregion Methods

        #region Events

        event EventHandler<UserNotificationRaisedEventArgs> OnNewNotification;

        #endregion Events
    }
}
