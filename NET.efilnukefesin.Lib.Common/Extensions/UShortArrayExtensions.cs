using System;
using System.Collections.Generic;
using System.Text;

namespace NET.efilnukefesin.Lib.Common.Extensions
{
    public static class UShortArrayExtensions
    {
        #region ConvertToText
        public static string ConvertToText(this ushort[] data)
        {
            string result = string.Empty;

            foreach (ushort number in data)
            {
                char character = (char)number;
                if (number == 0)
                {
                    character = ' ';
                }
                result += character;
            }

            return result.Trim();
        }
        #endregion ConvertToText
    }
}
