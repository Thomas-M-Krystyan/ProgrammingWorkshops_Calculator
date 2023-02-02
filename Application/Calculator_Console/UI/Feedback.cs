using Calculator_Console.Enums;
using Calculator_Console.Helpers;
using Calculator_Console.Validation;
using Operations.Implementation;

namespace Calculator_Console.UI
{
    internal static class Feedback
    {
        private static string _userChoice = string.Empty;

        /// <summary>
        /// Process the "mathematical operation" user input.
        /// </summary>
        internal static bool GetValidOperation(out ushort operationNumber)
        {
            // 1. Ask for the math operation or cancellation
            Messages.SelectCalculatorOperation(_userChoice);
            _userChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(_userChoice))
            {
                Environment.Exit(0);
            }

            // 3. Validate if the user input is numeric
            var isSuccess = Validate.IsInputNumeric(ref _userChoice, out operationNumber) &&
                            // 4. Validate if there is corresponding math operation
                            Validate.IsOperationExisting(operationNumber);

            if (isSuccess)
            {
                ClearAnswers();
            }

            return isSuccess;
        }
        
        /// <summary>
        /// Collects the floating point input ("the number") required to process the selected mathematical operation.
        /// </summary>
        internal static bool GetValidParameter(ushort operationNumber, Number whichNumber, out double selectedValue)
        {
            // 1. Ask for the number or cancellation
            Messages.SelectNumber(_userChoice, operationNumber, whichNumber);
            _userChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(_userChoice))
            {
                Environment.Exit(0);
            }

            // 3. Cancel option
            if (Validate.IsCancelRequested(_userChoice))
            {
                ClearAnswers();  // Reset the previous user choice (to clear "wrong choices" on the previous screen)
                
                Program.ApplicationWorkflow();
            }

            // 4. Validate if the user input is floating point number
            var isSuccess = Validate.IsInputDouble(ref _userChoice, out selectedValue);

            if (isSuccess)
            {
                ClearAnswers();
            }

            return isSuccess;
        }

        /// <summary>
        /// Performs the specific math operation with given parameters (numbers).
        /// </summary>
        internal static void PerformOperation(ushort operationNumber, double firstNumber, double secondNumber)
        {
            // 1. Calculation and showing the result
            try
            {
                // Resolve calculation method
                var method = Helper.Methods[operationNumber];

                // Execute it
                //var result = method.Invoke(firstNumber, secondNumber);
                var result = new Arithmetic().Add(firstNumber, secondNumber);

                // SUCCESS: Print the result
                Messages.PrintResult(result);
            }
            catch (Exception exception)
            {
                // FAILURE: Print the error
                Console.WriteLine(exception.Message);
            }
            
            var userChoice = Console.ReadKey();

            // 2. Quit option
            if (userChoice.Key == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            // 3. Cancel option
            else
            {
                Program.ApplicationWorkflow();
            }
        }

        /// <summary>
        /// Clears cached user choice answers, for example to prevent showing error messages on
        /// the next screen (still using cached result) when the proper option was chosen before.
        /// </summary>
        private static void ClearAnswers()
        {
            _userChoice = string.Empty;
        }
    }
}
