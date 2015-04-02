using System;
using System.Runtime.InteropServices;

namespace ArrayCs
{
    public static class StringArray
    {
        /// <summary>
        /// This is an string extension to split string into array at position index provided.
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="splitAt"></param>
        /// <param name="options"></param>
        /// <returns>string array</returns>
        [ComVisibleAttribute(false)]
        public static string[] Split(this string inputValue, int splitAt, StringSplitOptions options = StringSplitOptions.None)
        {
            if (inputValue == null) throw new ArgumentNullException("inputValue");
            if (splitAt < 0) throw new ArgumentOutOfRangeException("splitAt", splitAt, "splitAt cannot be less than 0");

            if (options == StringSplitOptions.RemoveEmptyEntries && inputValue.Trim().Length == 0)
                return null;
            if (splitAt == 0)
                return new string[] { inputValue};
            if (options == StringSplitOptions.RemoveEmptyEntries && string.IsNullOrEmpty(inputValue.Substring(splitAt).Trim()))
                return new string[] { inputValue.Substring(0, splitAt) };
            return new string[] { inputValue.Substring(0, splitAt), inputValue.Substring(splitAt) };
        }
    }
}