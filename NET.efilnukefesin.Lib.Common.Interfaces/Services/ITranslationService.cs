using NET.efilnukefesin.Lib.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Services
{
    [ArchitectureLayer("User Interface")]
    public interface ITranslationService : IService
    {
        #region Properties

        #endregion Properties

        #region Methods

        void Add(string Locale, string Key, string Text);
        string Get(string Locale, string Key);
        string Get(string Locale, string Key, params object[] Parameters);
        int GetNumberOfLanguagesFor(string Key);
        int GetNumberOfTranslations(string Locale);

        #endregion Methods
    }
}
