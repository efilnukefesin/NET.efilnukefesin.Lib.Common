using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class ArchitectureLayerAttribute : Attribute
    {
        #region Properties

        public string LayerName { get; private set; }

        #endregion Properties

        #region Construction

        public ArchitectureLayerAttribute(string LayerName)
        {
            this.LayerName = LayerName;
        }

        #endregion Construction

        #region Methods

        #endregion Methods
    }
}
