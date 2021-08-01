using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class TranslationItem : ITranslationItem
    {
        #region Properties

        public string Name { get; private set; }

        public string Locale { get; private set; }

        public string Text { get; private set; }

        #endregion Properties

        #region Construction

        public TranslationItem(string Name, string Locale, string Text)
        {
            this.Name = Name;
            this.Locale = Locale;
            this.Text = Text;
        }

        #endregion Construction

        #region Methods

        #endregion Methods

        #region Events

        #endregion Events
    }
}
