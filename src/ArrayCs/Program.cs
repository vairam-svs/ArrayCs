using System;

namespace ArrayCs
{
    public class Program
    {
        private static void FibonaciSeqSumByFormula()
        {

            int sumVal = 0;
            Func<double, double> seqSum = (double nthIndex) =>
            {
                //http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html
                //http://pumas.jpl.nasa.gov/
                //http://pumas.jpl.nasa.gov/examples/index.php?order_by=keyword
                // return (System.Math.Pow((1 + System.Math.Sqrt(5)) / 2, nthIndex) - System.Math.Pow((1 - System.Math.Sqrt(5)) / 2, nthIndex))/System.Math.Sqrt(5);
                //return 1 + 2.23606797749979;
                //return ((System.Math.Pow((1+2.23606797749979)/2, 2) - (-System.Math.Pow((1-2.23606797749979)/2, 2))) / 2.236067977)/2.23606797749979;
                //TODO: to find why this is not working.
                return 0;
            };
            sumVal = (int)(seqSum(2));
            Console.WriteLine(sumVal);
            Console.WriteLine(seqSum(2));
            /*
            var i=getInput("document.Frsqrt.n.value","n","Z");
  var P=Math.pow((Math.sqrt(5)+1)/2,i)/Math.sqrt(5),
      p=Math.pow((-Math.sqrt(5)+1)/2,i)/Math.sqrt(5);
 if(!isFinite(p)|| !isFinite(P)){alert("n is too large - sorry!");ERROR()};
  document.FrsqrtR.res.value += (i<0?" ((-phi)^":"(Phi^")+i+")/sqrt(5) = "+(i<0?p:P)+
  (i<0&inacc(p) || i>0&inacc(P)
   ?" may not be accurate enough"
   :"    \r rounds to Fib("+i+") ="+Math.round(i<0?p:P)
  )+"\r";
  */
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

        /// <summary>
        ///Action sample https://msdn.microsoft.com/en-us/library/vstudio/018hxwa8%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="args"></param>
        public void Main(string[] args)
        {
            Func<bool> continueExecution = () =>
            {
                Console.WriteLine("Do you want to quit all programs");
                string continueValue = Console.ReadLine().ToString().Trim().ToUpperInvariant();
                if (string.IsNullOrEmpty(continueValue) || continueValue != "2")
                    continueValue = "Y";
                return (continueValue == "Y");
            };

            int indexCount = 4;
            while (!continueExecution())
            {
                switch (indexCount--)
                {
                    case 4:
                        FibonaciSeqSumByFormula();
                        break;
                    case 3:
                        FibonacciSeqSum();
                        break;
                    case 2:
                        FibonacciSeq();
                        break;
                    case 1:
                        ParseLong();
                        break;
                    case 0:
                        StringSplitAtPosition();
                        break;
                    default:
                        break;
                }

            }
        }


    }
}
