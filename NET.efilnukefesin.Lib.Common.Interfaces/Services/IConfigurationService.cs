using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Application Control")]
    public interface IConfigurationService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        bool Add<T>(string Name, T Value);
        T Get<T>(string Name);
        bool Exists<T>(string Name);

        #endregion Methods
    }
}
