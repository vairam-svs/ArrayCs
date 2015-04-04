using Microsoft.AspNet.Diagnostics.Views;
using System;
using System.Linq.Expressions;
using System.Text;


namespace ArrayCs
{
    public static class MemberInfoGetting
    {
        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }

    public static class NumberParser
    {
        /// <summary>
        /// Construct from https://msdn.microsoft.com/en-us/library/vstudio/kdcak6ye%28v=vs.100%29.aspx
        /// Extension method - https://msdn.microsoft.com/en-us/library/vstudio/bb383977%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static long ParseLong(this string inputValue)
        {
            //is it small enough for conversion for thios 
            //TODO:to replace parameter name with actual parameter name using stackframe (need to find the package for ASP.NET 5.0
            //http://joelabrahamsson.com/getting-property-and-method-names-using-static-reflection-in-c/ close to,
            //it still shows inputValue but not number the name of the variable
            //to which this extension method is attached in calling location
            if (inputValue.Trim().Length > 19)
                throw new ArgumentOutOfRangeException(MemberInfoGetting.GetMemberName(() => inputValue), "Number of digits cannot be greater than 19 digits longer");

            // Create two different encodings.
            Encoding ascii = Encoding.ASCII;
            Encoding unicode = Encoding.Unicode;
            //remove leading zeros.
            inputValue = inputValue.TrimStart('0');
            // Convert the string into a byte array. 
            byte[] unicodeBytes = unicode.GetBytes(inputValue);

            // Perform the conversion from one encoding to the other. 
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);
            Int64 outPutValue = 0;
            int index = 0;
            foreach(byte val in asciiBytes)
            {
                if (!(val >= 48 && val <= 57))
                    throw new ArgumentOutOfRangeException("string does not contain numeric characters");
                int intval = 0;
                switch (val)
                {
                    case 48:
                        intval = 0;
                        break;
                    case 49:
                        intval = 1;
                        break;
                    case 50:
                        intval = 2;
                        break;
                    case 51:
                        intval = 3;
                        break;
                    case 52:
                        intval = 4;
                        break;
                    case 53:
                        intval = 5;
                        break;
                    case 54:
                        intval = 6;
                        break;
                    case 55:
                        intval = 7;
                        break;
                    case 56:
                        intval = 8;
                        break;
                    case 57:
                        intval = 9;
                        break;
                }
                outPutValue += intval * (long)System.Math.Pow(10, asciiBytes.Length - ++index);
            }
            return outPutValue;
        }
    }
}