using Calculator_Console.Enums;
using Calculator_Console.Validation;
using Environment = System.Environment;

namespace Calculator_Console.UI
{
    internal static class Feedback
    {
        /// <summary>
        /// Process the "mathematical operation" user input.
        /// </summary>
        /// <para>
        /// Quits the application on request.
        /// </para>
        internal static bool GetValidOperation(ref string userChoice, out ushort operationNumber, out Request request)
        {
            operationNumber = default;
            request = Request.Continue;

            // 1. Ask for the math operation or cancellation
            Messages.SelectCalculatorOperation(userChoice);
            userChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(userChoice))
            {
                request = Request.Quit;

                return true;
            }

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
        internal static bool GetValidParameter(out double firstNumber, ushort operationNumber, Number whichNumber, out Request request)
        {
            firstNumber = default;
            request = Request.Continue;

            // 1. Ask for the number or cancellation
            Messages.SelectNumber(operationNumber, whichNumber);
            var userChoice = Console.ReadLine();
            
            // 2. Quit option
            if (Validate.IsQuitRequested(userChoice))
            {
                request = Request.Quit;

                return true;
            }
            
            // 3. Cancel option
            if (Validate.IsCancelRequested(userChoice))
            {
                request = Request.Cancel;

                return true;
            }

            // 4. Validate if the user input is floating point number
            return Validate.IsInputDouble(ref userChoice, out firstNumber);
        }
        
        /// <summary>
        /// Quits the application.
        /// </summary>
        internal static void Quit()
        {
            Environment.Exit(0);
        }
    }
}
