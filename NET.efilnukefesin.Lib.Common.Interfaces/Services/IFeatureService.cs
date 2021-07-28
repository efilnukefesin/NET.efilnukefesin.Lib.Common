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
        void AddTimed(string Name, int MilliSecondsFromNow, string Placename);
        void AddTimed(string Name, DateTime TargetDate, string Placename);
        void AddRandom(string Name, int Numerator, int Denominator, bool IsStaticRandom = true);

        #endregion Methods
    }
}
