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
        /// <para>
        /// Quits the application on request.
        /// </para>
        internal static bool GetMathOperation(ref string userChoice, out ushort operationNumber)
        {
            // 1. Ask for the math operation or cancellation
            Messages.SelectCalculatorOperation(userChoice);
            userChoice = Console.ReadLine();

            // 2. Quit if requested
            ProcessQuitRequest(userChoice);

            // 3. Validate if the user input is numeric
            return Validate.IsInputNumeric(ref userChoice, out operationNumber) &&
                   // 4. Validate if there is corresponding math operation
                   Validate.IsOperationExisting(operationNumber);
        }
        
        /// <summary>
        /// Collects the floating point input ("the number") required to process the selected mathematical operation.
        /// </summary>
        /// <para>
        /// Quits the application on request.
        /// </para>
        internal static bool GetMathParameter(out double firstNumber, ushort operationNumber, string whichNumber)
        {
            // 1. Ask for the number or cancellation
            Messages.SelectNumber(operationNumber, whichNumber);
            var userChoice = Console.ReadLine();
            
            // 2. Quit if requested
            ProcessQuitRequest(userChoice);

            // 3. Validate if the user input is floating point number
            return Validate.IsInputDouble(ref userChoice, out firstNumber);
        }

        /// <summary>
        /// Checks if the Quit operation was requested.
        /// </summary>
        private static void ProcessQuitRequest(string userChoice)
        {
            if (string.Equals(userChoice, Keys.Quit, StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        }
    }
}
