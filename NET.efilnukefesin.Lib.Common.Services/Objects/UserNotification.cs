using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class UserNotification : IUserNotification
    {
        #region Properties

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Subject { get; private set; }

        public string Text { get; private set; }

        #endregion Properties

        #region Construction

        public UserNotification(string Subject, string Text)
        {
            this.Subject = Subject;
            this.Text = Text;
        }

        #endregion Construction

        #region Methods

        #endregion Methods
    }
}
