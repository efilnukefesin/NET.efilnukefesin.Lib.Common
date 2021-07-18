using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.EventArgs
{
    public class UserNotificationRaisedEventArgs : System.EventArgs
    {
        #region Properties

        public IUserNotification UserNotification { get; private set; }

        #endregion Properties

        #region Construction

        public UserNotificationRaisedEventArgs(IUserNotification UserNotification)
        {
            this.UserNotification = UserNotification;
        }

        #endregion Construction
    }
}
