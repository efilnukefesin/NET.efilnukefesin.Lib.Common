using NET.efilnukefesin.Lib.Common.Interfaces.EventArgs;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class UserNotificationService : IUserNotificationService
    {
        #region Properties

        private ILogService logService;

        #endregion Properties

        #region Construction

        public UserNotificationService(ILogService LogService)
        {
            this.logService = LogService;
        }

        #endregion Construction

        #region Methods

        #region Enqueue
        public void Enqueue(IUserNotification Notification)
        {
            this.logService.Debug("UserNotificationService", "Enqueue", "Received a UserNotification");

            if (this.OnNewNotification != null)
            {
                this.logService.Info("UserNotificationService", "Enqueue", "Invoked a UserNotification Event");
                this.OnNewNotification.Invoke(this, new UserNotificationRaisedEventArgs(Notification));
            }
            else
            {
                this.logService.Warning("UserNotificationService", "Enqueue", "No Event is attached, therefore no event is raised");
            }

            this.logService.Debug("UserNotificationService", "Enqueue", "Finished receiving a UserNotification");
        }
        #endregion Enqueue

        #endregion Methods

        #region Events

        public event EventHandler<UserNotificationRaisedEventArgs> OnNewNotification;

        #endregion Events
    }
}
