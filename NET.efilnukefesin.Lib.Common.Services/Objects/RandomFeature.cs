using NET.efilnukefesin.Lib.Common.Interfaces;
using NET.efilnukefesin.Lib.Common.Interfaces.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Services.Objects
{
    public class RandomFeature : BaseFeature, IInitialize
    {
        #region Properties

        public bool IsInitialized { get; private set; } = false;

        private int Numerator;
        private int Denominator;

        private bool IsStaticRandom = false;  // random value is generated at start and not changed (true) or randomized every time (false)

        private bool Value = false;

        private Random Random;

        #endregion Properties

        #region Construction

        public RandomFeature(string Name, int Numerator, int Denominator, bool IsStaticRandom = true)
            : base(Name)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            this.IsStaticRandom = IsStaticRandom;
        }
        #endregion Construction

        #region Methods

        #region Initialize
        public void Initialize()
        {
            if (!this.IsInitialized)
            {
                this.Random = new Random();

                if (this.IsStaticRandom)
                {
                    this.Value = this.Random.Next(this.Denominator) <= this.Numerator;
                }

                this.IsInitialized = true;
            }
        }
        #endregion Initialize

        #region Check
        public override bool Check()
        {
            bool result = false;

            if (!this.IsStaticRandom)
            {
                this.Value = this.Random.Next(this.Denominator) <= this.Numerator;
            }

            result = this.Value;

            return result;
        }
        #endregion Check

        #endregion Methods
    }
}
