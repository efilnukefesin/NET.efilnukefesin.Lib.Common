using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Data Access")]
    public interface IPersistanceService : IService, IInitialize
    {
        #region Properties

        #endregion Properties

        #region Methods

        bool AddEndpoint(string EndPoint, string Path);
        void Write<T>(string EndPoint, T Value);
        T Read<T>(string EndPoint);
        bool ValueExists(string EndPoint);
        bool Exists(string EndPoint);

        #endregion Methods
    }
}
