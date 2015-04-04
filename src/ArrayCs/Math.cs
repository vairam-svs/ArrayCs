using System;

namespace ArrayCs
{
    public static class Math
    {
        /// <summary>
        /// Generate the first n number of fibnocci sequence number.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long[] FibnocciSequence(long n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n", "Fibonacci Sequence cannot be generated for value less than 0");

            if (n == 1)
                return new long[] { 1 };
            if (n == 2)
                return new long[] { 1 ,1};
            long[] returnValue = new long[n];
            long prevValue = 1;
            long prevPrevValue = 1;
            returnValue[0] = returnValue[1] = 1;
            for (int i = 3; i <= n; i++)
            {
                returnValue[i - 1] = prevPrevValue + prevValue;
                prevPrevValue = prevValue;
                prevValue = returnValue[i-1];
            }
            
            return returnValue;
        }

        public static long FibnocciSequenceSum(long n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("n", "Fibonacci Sequence cannot be generated for value less than 0");

            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            long prevValue = 1;
            long prevPrevValue = 1;
            long returnValue = prevPrevValue + prevValue;
            for (int i = 3; i <= n; i++)
            {
                long nextValue = prevPrevValue + prevValue;
                returnValue += nextValue;
                //change next values.
                prevPrevValue = prevValue;
                prevValue = nextValue;
            }
            return returnValue;
        }
    }
}