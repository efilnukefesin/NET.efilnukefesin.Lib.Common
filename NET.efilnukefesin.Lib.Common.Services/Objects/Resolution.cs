using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class Resolution : IResolution
    {
        #region Properties

        public int Width { get; private set; }

        public int Height { get; private set; }

        #endregion Properties

        #region Construction

        public Resolution(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        #endregion Construction

        #region Methods

        #endregion Methods
    }
}
