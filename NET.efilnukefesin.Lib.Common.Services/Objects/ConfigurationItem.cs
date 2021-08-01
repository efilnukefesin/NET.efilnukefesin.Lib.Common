using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class ConfigurationItem<T> : IConfigurationItem
    {
        #region Properties

        public string Name { get; private set; }

        public object Value { get; private set; }

        #endregion Properties

        #region Construction

        public ConfigurationItem(string Name, T Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        #endregion Construction

        #region Methods

        #region Get
        public T Get()
        {
            return (T)this.Value;
        }
        #endregion Get

        #endregion Methods
    }
}
