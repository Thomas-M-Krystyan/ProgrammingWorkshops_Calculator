using Calculator_Console.Constants;
using Calculator_Console.Validation;

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

            // 2. Validate if the user input is numeric
            if (!Validate.IsInputNumeric(ref userChoice, out var value))
            {
                return false;
            }

            operationNumber = value;

            // 3. Validate if there is such calculator operation
            return Validate.IsOperationExisting(value);
        }

        /// <summary>
        /// Handles the eventual request to Quit the application.
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
