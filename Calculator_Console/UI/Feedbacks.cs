using Calculator_Console.Constants;
using Calculator_Console.Validation;
using Environment = System.Environment;

namespace Calculator_Console.UI
{
    internal static class Feedbacks
    {
        /// <summary>
        /// Process the "mathematical operation" user input.
        /// </summary>
        internal static bool GetMathOperation(ref string userChoice, ref ushort operationNumber)
        {
            // 1. Ask for calculator operation
            Messages.SelectCalculatorOperation(userChoice);
            userChoice = Console.ReadLine();

            // 2. Quit if requested
            ProcessQuitRequest(userChoice);

            // 3. Validate if the user input is numeric
            if (!Validate.IsInputNumeric(ref userChoice, out var value))
            {
                return false;
            }

            operationNumber = value;

            // 4. Validate if there is such calculator operation
            return Validate.IsOperationExisting(value);
        }

        internal static bool GetMathParameter(ref double firstNumber, ushort operationNumber, string whichNumber)
        {
            // 1. Ask for the number or cancellation
            Messages.SelectNumber(operationNumber, whichNumber);
            var userChoice = Console.ReadLine();
            
            // 2. Quit if requested
            ProcessQuitRequest(userChoice);

            // 3. Validate if the user input is floating point number
            if (!Validate.IsInputDouble(ref userChoice, out var value))
            {
                return false;
            }

            firstNumber = value;

            return true;
        }

        /// <summary>
        /// Checks if the Quit operation was requested.
        /// </summary>
        internal static void ProcessQuitRequest(string userChoice)
        {
            if (string.Equals(userChoice, Keys.Quit, StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        }
    }
}
