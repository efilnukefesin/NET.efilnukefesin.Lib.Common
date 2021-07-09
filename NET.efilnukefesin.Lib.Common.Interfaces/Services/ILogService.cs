using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    public interface ILogService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        void Fatal();
        void Error();
        void Warning();
        void Info();
        void Debug();

        #endregion Methods
    }
}
