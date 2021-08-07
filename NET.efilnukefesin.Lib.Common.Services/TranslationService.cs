using NET.efilnukefesin.Lib.Common.Interfaces;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class TranslationService : ITranslationService, IInitialize
    {
        #region Properties

        public bool IsInitialized { get; private set; }

        private ILogService logService;

        private List<ITranslationItem> items;

        #endregion Properties

        #region Construction

        public TranslationService(ILogService LogService)
        {
            this.logService = LogService;
        }

        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                this.items = new List<ITranslationItem>();

                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region Add
        public void Add(string Locale, string Key, string Text)
        {
            if (!this.Exists(Locale, Key))
            {
                this.items.Add(DiContainer.Resolve<TranslationItem>(Key, Locale, Text));
                this.logService.Debug("TranslationService", "Add", $"Added an Entry for '{Key}' in '{Locale}': '{Text}'.");
            }
            else
            {
                this.logService.Warning("TranslationService", "Add", $"Did not add an Entry for '{Key}' in '{Locale}': '{Text}' as there is already an entry existing!");
            }
        }
        #endregion Add

        #region Get
        public string Get(string Locale, string Key)
        {
            string result = string.Empty;

            result = this.GetText(Locale, Key);

            return result;
        }
        #endregion Get

        #region Get
        public string Get(string Locale, string Key, params object[] Parameters)
        {
            string result = string.Empty;

            result = String.Format(this.GetText(Locale, Key), Parameters);

            return result;
        }
        #endregion Get

        #region GetNumberOfLanguagesFor
        public int GetNumberOfLanguagesFor(string Key)
        {
            int result = 0;

            if (this.items.Any(x => x.Name.Equals(Key)))
            {
                result = this.items.Where(x => x.Name.Equals(Key)).Count();
            }

            return result;
        }
        #endregion GetNumberOfLanguagesFor

        #region GetNumberOfTranslations
        public int GetNumberOfTranslations(string Locale)
        {
            int result = 0;

            if (this.items.Any(x => x.Locale.Equals(Locale)))
            {
                result = this.items.Where(x => x.Locale.Equals(Locale)).Count();
            }

            return result;
        }
        #endregion GetNumberOfTranslations

        #region Exists
        private bool Exists(string Locale, string Key)
        {
            bool result = false;

            result = this.items.Any(x => x.Name.Equals(Key) && x.Locale.Equals(Locale));

            return result;
        }
        #endregion Exists

        #region GetText
        private string GetText(string Locale, string Key)
        {
            string result = string.Empty;

            if (this.Exists(Locale, Key))
            {
                result = this.items.Where(x => x.Locale.Equals(Locale) && x.Name.Equals(Key)).FirstOrDefault().Text;
            }
            else if (this.Exists("", Key))
            {
                // return invariant info
                result = this.items.Where(x => x.Locale.Equals("") && x.Name.Equals(Key)).FirstOrDefault().Text;
            }

            return result;
        }
        #endregion GetText

        #endregion Methods

        #region Events

        #endregion Events
    }
}
