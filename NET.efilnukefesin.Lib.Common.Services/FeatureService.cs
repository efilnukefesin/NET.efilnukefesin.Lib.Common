using NET.efilnukefesin.Lib.Common.Interfaces;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class FeatureService : IFeatureService, IInitialize
    {
        #region Properties

        public bool IsInitialized { get; private set; }

        private List<string> StaticFeatures = new List<string>();

        private ITimeService timeService;
        private ILogService logService;

        #endregion Properties

        #region Construction

        public FeatureService(ILogService LogService, ITimeService TimeService)
        {
            this.logService = LogService;
            this.timeService = TimeService;
        }

        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                StaticFeatures.Clear();

                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region AddStatic
        public void AddStatic(string Name)
        {
            if (!this.StaticFeatures.Contains(Name))
            {
                this.StaticFeatures.Add(Name);
                this.logService.Info("FeatureService", "AddStatic", $"Added Static Feature Toggle '{Name}'.");
            }
            else
            {
                this.logService.Info("FeatureService", "AddStatic", $"Could not add Static Feature Toggle '{Name}' as it already exists, no need to worry though.");
            }
        }
        #endregion AddStatic

        #region Check
        public bool Check(string Name)
        {
            bool result = false;
            result = this.Exists(Name);
            this.logService.Info("FeatureService", "Check", $"Checked for Feature Toggle '{Name}' with result '{result}'.");
            return result;
        }
        #endregion Check

        #region Exists
        public bool Exists(string Name)
        {
            bool result = false;
            result = this.StaticFeatures.Contains(Name);
            this.logService.Info("FeatureService", "Exists", $"Checked for existance of Feature Toggle '{Name}' with result '{result}'.");
            return result;
        }
        #endregion Exists

        #endregion Methods
    }
}
