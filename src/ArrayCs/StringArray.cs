using System;
using System.Runtime.InteropServices;

//using System.Collections.Generic;

namespace ArrayCs
{
    public static class StringArray
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="splitInterval"></param>
        /// <param name="splitAtIntervals"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [ComVisibleAttribute(false)]
        public static string[] Split(this string inputValue, int splitInterval, bool splitAtIntervals=true, StringSplitOptions options = StringSplitOptions.None)
        {
            if (inputValue == null) throw new ArgumentNullException("inputValue");

            if (splitInterval < 0) throw new ArgumentOutOfRangeException("splitAt", splitInterval, "splitAt cannot be less than 0");

            if (options == StringSplitOptions.RemoveEmptyEntries && inputValue.Trim().Length == 0)
                return null;

            if (splitInterval == 0)
                return new string[] { inputValue };

            //if there is only one item 
            if (options == StringSplitOptions.RemoveEmptyEntries && string.IsNullOrEmpty(inputValue.Substring(splitInterval).Trim()))
                return new string[] { inputValue.Substring(0, splitInterval) };

            //if to split only once.
            if (splitAtIntervals == false)
                return new string[] { inputValue.Substring(0, splitInterval), inputValue.Substring(splitInterval) };

            string[] stringList = new string[(int)System.Math.Ceiling(inputValue.Length / (decimal)splitInterval)];
            //start
            int stringListIndex = 0;
            while(!string.IsNullOrEmpty(inputValue))
            {
                stringList[stringListIndex++] = inputValue.Substring(0, (splitInterval < inputValue.Length ? splitInterval : inputValue.Length));
                if (splitInterval < inputValue.Length)
                    inputValue = inputValue.Substring(splitInterval);
                else
                    inputValue = string.Empty;
            }
            return stringList;
        }
    }
}