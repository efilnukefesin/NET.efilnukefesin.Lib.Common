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

        #endregion Properties

        #region Construction

        public FeatureService(ITimeService TimeService)
        {
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
            }
        }
        #endregion AddStatic

        #region Check
        public bool Check(string Name)
        {
            return this.Exists(Name);
        }
        #endregion Check

        #region Exists
        public bool Exists(string Name)
        {
            return this.StaticFeatures.Contains(Name);
        }
        #endregion Exists

        #endregion Methods
    }
}
