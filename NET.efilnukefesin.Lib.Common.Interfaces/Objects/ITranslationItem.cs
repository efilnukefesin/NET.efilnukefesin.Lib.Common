using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Interfaces.Objects
{
    public interface ITranslationItem : IName
    {
        #region Properties

        string Locale { get; }
        string Text{ get; }

        #endregion Properties

        #region Methods

        #endregion Methods
    }
}
