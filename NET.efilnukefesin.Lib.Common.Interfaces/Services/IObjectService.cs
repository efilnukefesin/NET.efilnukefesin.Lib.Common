using NET.efilnukefesin.Lib.Common.Attributes;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Application Control")]
    public interface IObjectService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        T Create<T>(params object[] Parameters) where T : class, IBaseObject;
        int Count();

        #endregion Methods  
    }
}
