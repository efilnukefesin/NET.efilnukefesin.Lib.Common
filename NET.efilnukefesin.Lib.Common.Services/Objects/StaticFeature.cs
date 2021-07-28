using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class StaticFeature : BaseFeature
    {
        #region Properties

        public string Name { get; private set; }

        private bool IsActive;

        #endregion Properties

        #region Construction

        public StaticFeature(string Name, bool IsActive = true)
            : base(Name)
        {
            this.IsActive = IsActive;
        }

        #endregion Construction

        #region Methods

        #region Check
        public override bool Check()
        {
            return this.IsActive;
        }
        #endregion Check

        #endregion Methods
    }
}
