using NET.efilnukefesin.Lib.Common.Extensions;
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
    public class FeatureService : IFeatureService, IInitialize
    {
        #region Properties

        public bool IsInitialized { get; private set; }

        private List<IFeature> features = new List<IFeature>();

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
                this.features.Clear();

                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region AddStatic
        public void AddStatic(string Name)
        {
            this.AddFeature<StaticFeature>(Name);
        }
        #endregion AddStatic

        #region AddTimed
        public void AddTimed(string Name, int MilliSecondsFromNow)
        {
            this.AddFeature<TimedFeature>(Name, MilliSecondsFromNow);
        }
        #endregion AddTimed

        #region AddTimed
        public void AddTimed(string Name, DateTime TargetDate)
        {
            this.AddFeature<TimedFeature>(Name, TargetDate);
        }
        #endregion AddTimed

        #region AddRandom
        public void AddRandom(string Name, int Numerator, int Denominator, bool IsStaticRandom = true)
        {
            this.AddFeature<RandomFeature>(Name, Numerator, Denominator, IsStaticRandom);
        }
        #endregion AddRandom

        #region AddFeature
        private void AddFeature<T>(string Name, params object[] Parameters) where T : IFeature
        {
            if (!this.Exists(Name))
            {
                this.features.Add(DiContainer.Resolve<T>(Parameters.Prepend(Name)));
                this.logService.Info("FeatureService", "AddFeature", $"Added Feature Toggle '{Name}' of Type '{typeof(T)}'.");
            }
            else
            {
                this.logService.Info("FeatureService", "AddFeature", $"Could not add Feature Toggle '{Name}' as it already exists, no need to worry though.");
            }
        }
        #endregion AddFeature

        #region Check
        public bool Check(string Name)
        {
            bool result = false;
            result = this.CheckFeature(Name);
            this.logService.Info("FeatureService", "Check", $"Checked for Feature Toggle '{Name}' with result '{result}'.");
            return result;
        }
        #endregion Check

        #region CheckFeature
        private bool CheckFeature(string Name)
        {
            bool result = false;

            if (this.Exists(Name))
            {
                result = this.features.Where(x => x.Name.Equals(Name)).FirstOrDefault().Check();
            }

            return result;
        }
        #endregion CheckFeature

        #region Exists
        public bool Exists(string Name)
        {
            bool result = false;
            result = this.features.Any(x => x.Name.Equals(Name));
            this.logService.Info("FeatureService", "Exists", $"Checked for existance of Feature Toggle '{Name}' with result '{result}'.");
            return result;
        }
        #endregion Exists

        #endregion Methods
    }
}
