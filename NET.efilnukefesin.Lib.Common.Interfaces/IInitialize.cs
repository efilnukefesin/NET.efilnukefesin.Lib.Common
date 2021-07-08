using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces
{
    public interface IInitialize
    {
        #region Properties

        bool IsInitialized { get; }

        #endregion Properties

        #region Methods

        void Initialize();

        #endregion Methods
    }
}
