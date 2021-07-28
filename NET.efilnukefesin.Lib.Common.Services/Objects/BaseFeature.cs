using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public abstract class BaseFeature : IFeature
    {

        #region Properties

        public string Name { get; private set; }

        #endregion Properties

        #region Construction

        public BaseFeature(string Name)
        {
            this.Name = Name;
        }

        #endregion Construction

        #region Methods

        public abstract bool Check();

        #endregion Methods

        #region Events

        #endregion Events        
    }
}
