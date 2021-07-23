using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("Application Control")]
    public interface IFeatureService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        void AddStatic(string Name);
        bool Exists(string Name);
        bool Check(string Name);

        #endregion Methods
    }
}
