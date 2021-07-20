using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Extensions
{
    public static class ObjectExtensions
    {
        #region DoesImplementInterface
        public static bool DoesImplementInterface<I>(this object Object)
        {
            bool result = false;

            if (Object is I)
            {
                result = true;
            }

            return result;
        }
        #endregion DoesImplementInterface
    }
}
