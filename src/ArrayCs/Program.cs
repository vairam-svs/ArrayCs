using System;

namespace ArrayCs
{
    public class Program
    {
        /// <summary>
        ///Action sample https://msdn.microsoft.com/en-us/library/vstudio/018hxwa8%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="args"></param>
        public void Main(string[] args)
        {
            FibonacciSeqSum();
            FibonacciSeq();
            ParseLong();
            StringSplitAtPosition();
        }

        private static void FibonacciSeqSum()
        {
            ConsoleActions.PerformAction(
                "FibonacciSeqSum",
                "Enter nth number to generate Fibonacci sequence sum for", "Input number {0} to generate the Fibonacci sequence sum for",
                 new Action<string>((string number) =>
                 {
                     long inputValue;
                     if (!(Int64.TryParse(number, out inputValue)))
                         throw new ArgumentException("Argument entered {0} is not a valid number", number);

                     Console.WriteLine(Math.FibnocciSequenceSum(inputValue));
                 }));
        }

        private static void FibonacciSeq()
        {
            ConsoleActions.PerformAction(
                "FibonacciSeq",
                "Enter nth number to generate Fibonacci sequence for", "Input number {0} to generate the Fibonacci sequence for",
                 new Action<string>((string number) =>
                 {
                     long inputValue;
                     if (!(Int64.TryParse(number, out inputValue)))
                         throw new ArgumentException("Argument entered {0} is not a valid number", number);

                     foreach (long seq in Math.FibnocciSequence(inputValue))
                         Console.WriteLine(seq);
                 }));
        }

        private static void ParseLong()
        {
            ConsoleActions.PerformAction(
                "ParseInt",
                "Enter a string of number to convert", "Input String {0} to convert as number",
                 new Action<string>((string number) =>
                 {
                     Console.WriteLine(number.ParseLong());
                 }));
        }

        /// <summary>
        /// 
        /// </summary>
        private static void StringSplitAtPosition()
        {
            ConsoleActions.PerformAction(
                "StringSplitAtPosition",
                "Enter a string to split at length 6", 
                "Input String {0} split into array at length 6 is as follows",
                 new Action<string>((string writeLine) =>
                 {
                     //begin action
                     string[] arrayOfString = writeLine.Split(6);
                     foreach (string stringvalueAt in arrayOfString)
                     {
                         Console.WriteLine(stringvalueAt);
                     }
                     //end action
                 }));
        }


    }
}
