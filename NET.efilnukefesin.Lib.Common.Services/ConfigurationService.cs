using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using NET.efilnukefesin.Lib.Common.Interfaces.Services;
using NET.efilnukefesin.Lib.Common.Services.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services
{
    public class ConfigurationService : IConfigurationService
    {
        #region Properties

        private IPersistanceService persistanceService;

        private List<IConfigurationItem> items = new List<IConfigurationItem>();

        #endregion Properties

        #region Construction

        public ConfigurationService(IPersistanceService PersistanceService)
        {
            this.persistanceService = PersistanceService;
        }

        #endregion Construction

        #region Methods

        #region Add
        public bool Add<T>(string Name, T Value)
        {
            bool result = false;

            if (!this.Exists<T>(Name))
            {
                this.items.Add(DiContainer.Resolve<ConfigurationItem<T>>(Name, Value));
                result = true;
            }

            return result;
        }
        #endregion Add

        #region Exists
        public bool Exists<T>(string Name)
        {
            bool result = false;
            result = this.items.Any(x => x.Name.Equals(Name));
            return result;
        }
        #endregion Exists

        #region Get
        public T Get<T>(string Name)
        {
            T result = default;

            if (this.Exists<T>(Name))
            {
                result = (T)this.items.Where(x => x.Name.Equals(Name)).FirstOrDefault().Value;
            }

            return result;
        }
        #endregion Get

        #endregion Methods
    }
}
