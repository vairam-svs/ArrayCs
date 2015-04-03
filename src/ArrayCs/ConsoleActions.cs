using System;

namespace ArrayCs
{
    public static class ConsoleActions
    {
        /// <summary>
        /// Action sample https://msdn.microsoft.com/en-us/library/vstudio/018hxwa8%28v=vs.110%29.aspx
        /// "Run" an "Action " for the action passed as an argument.
        /// "Wait for the task to complete before proceeding to the next task.
        /// Use Function for repeatable question and add readability to code.
        ///     ---- https://msdn.microsoft.com/en-us/library/vstudio/bb549151%28v=vs.110%29.aspx
        /// </summary>
        /// <param name="messageForInput"></param>
        /// <param name="messageForOutput"></param>
        /// <param name="action"></param>
        public static void PerformAction(string taskName, string messageForInput, string messageForOutput, Action<string> action)
        {
            //https://msdn.microsoft.com/en-us/library/vstudio/bb549151%28v=vs.110%29.aspx
            Func<bool> continueProgram = () =>
            {
                Console.WriteLine("Do you want to continue to perform Action: {0}", taskName);
                string continueValue = Console.ReadLine().ToString().Trim().ToUpperInvariant();
                return (continueValue == "Y");
            };
            while (continueProgram())
            {
                Console.WriteLine(messageForInput);
                string readLine = Console.ReadLine();
                Console.WriteLine(messageForOutput, readLine);
                try
                {
                    action(readLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Sample Anonymous action declarations with and without arguments.
        /// </summary>
        private static void TestAction()
        {
            //samples of Action
            Action action2 = new Action(() => {
                Console.Write("hello");
            });
            Action<string> action = new Action<string>((string writeLine) => {
                string[] arrayOfString = writeLine.Split(6);
                foreach (string stringvalueAt in arrayOfString)
                {
                    Console.WriteLine(stringvalueAt);
                }
            });
        }
    }
}