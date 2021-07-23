using NET.efilnukefesin.Lib.Common.Interfaces.Services;
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

        private List<Tuple<string, Type, object>> items = new List<Tuple<string, Type, object>>();

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
                this.items.Add(new Tuple<string, Type, object>(Name, typeof(T), Value));
                result = true;
            }

            return result;
        }
        #endregion Add

        #region Exists
        public bool Exists<T>(string Name)
        {
            bool result = false;
            result = this.items.Any(x => x.Item1.Equals(Name));
            return result;
        }
        #endregion Exists

        #region Get
        public T Get<T>(string Name)
        {
            T result = default;

            if (this.Exists<T>(Name))
            {
                result = (T)this.items.Where(x => x.Item1.Equals(Name)).FirstOrDefault().Item3;
            }

            return result;
        }
        #endregion Get

        #endregion Methods
    }
}
