using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Extensions
{
    public static class ObjectExtensions
    {
        #region DoesImplementInterface: returns true, if an object implements a given interface
        /// <summary>
        /// returns true, if an object implements a given interface
        /// </summary>
        /// <typeparam name="I">the interface which should be implemented</typeparam>
        /// <param name="Object">the object to check</param>
        /// <returns>true, if Object implements I, otherwise false</returns>
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
