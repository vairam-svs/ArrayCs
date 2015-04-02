using System;

namespace ArrayCs
{
    public class Program
    {
        public void Main(string[] args)
        {
            string writeLine = "Hello World";
            bool doYouWantToContinue = true;
            while (doYouWantToContinue)
            {
                Console.WriteLine("Enter a string to split at length 6");
                writeLine = Console.ReadLine();
                Console.WriteLine("Input String {0} split into array at length 6 is as follows", writeLine);
                Action continueProgram = () => {
                    Console.WriteLine("Do you want to continue");
                    string continueValue = Console.ReadLine().ToString().Trim().ToUpperInvariant();
                    doYouWantToContinue = (continueValue == "Y");
                    return;
                };
                try
                {
                    string[] arrayOfString = writeLine.Split(6);
                    foreach (string stringvalueAt in arrayOfString)
                    {
                        Console.WriteLine(stringvalueAt);
                    }
                    continueProgram();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continueProgram();
                }
            }
        }
    }
}
