using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Extensions
{
    public static class ObjectArrayExtensions
    {
        #region Prepend: insert a value at the beginning of an object array
        /// <summary>
        /// insert a value at the beginning of an object array
        /// </summary>
        /// <param name="Source">the object array to prepend</param>
        /// <param name="Value">the value to insert</param>
        /// <returns>a new object array, Length + 1, Item[0] == Value</returns>
        public static object[] Prepend(this object[] Source, object Value)
        {
            object[] result;

            result = new object[Source.Length + 1];
            result[0] = Value;                                // set the prepended value
            Array.Copy(Source, 0, result, 1, Source.Length); // copy the old values

            return result;
        }
        #endregion Prepend
    }
}
