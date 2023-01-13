using Calculator_Console.Enums;
using Calculator_Console.Helpers;
using Calculator_Console.Validation;
using Operations.Implementation;

namespace Calculator_Console.UI
{
    internal static class Feedback
    {
        /// <summary>
        /// Process the "mathematical operation" user input.
        /// </summary>
        internal static ushort GetValidOperation()
        {
            var keepAsking = true;
            var userChoice = string.Empty;
            var operationNumber = default(ushort);

            while (keepAsking)
            {
                // 1. Ask for the math operation or cancellation
                Messages.SelectCalculatorOperation(userChoice);
                userChoice = Console.ReadLine();

                // 2. Quit option
                if (Validate.IsQuitRequested(userChoice))
                {
                    Environment.Exit(0);
                }

                // 3. Validate if the user input is numeric
                keepAsking = !(Validate.IsInputNumeric(ref userChoice, out operationNumber) &&
                               // 4. Validate if there is corresponding math operation
                               Validate.IsOperationExisting(operationNumber));
            }

            return operationNumber;
        }
        
        /// <summary>
        /// Collects the floating point input ("the number") required to process the selected mathematical operation.
        /// </summary>
        internal static double GetValidParameter(ushort operationNumber, Number whichNumber)
        {
            var keepAsking = true;
            var userChoice = string.Empty;
            var firstNumber = default(double);

            while (keepAsking)
            {
                // 1. Ask for the number or cancellation
                Messages.SelectNumber(userChoice, operationNumber, whichNumber);
                userChoice = Console.ReadLine();

                // 2. Quit option
                if (Validate.IsQuitRequested(userChoice))
                {
                    Environment.Exit(0);
                }

                // 3. Cancel option
                if (Validate.IsCancelRequested(userChoice))
                {
                    switch (whichNumber)
                    {
                        case Number.First:
                            // Ask for the math operation again
                            GetValidOperation();
                            break;

                        case Number.Second:
                            // Ask for the 1st number again
                            GetValidParameter(operationNumber, Number.First);
                            break;
                    }
                }

                // 4. Validate if the user input is floating point number
                keepAsking = !Validate.IsInputDouble(ref userChoice, out firstNumber);
            }

            return firstNumber;
        }

        /// <summary>
        /// Performs the specific math operation with given parameters (numbers).
        /// </summary>
        internal static void PerformOperation(double firstNumber, double secondNumber, ushort operationNumber)
        {
            // 1a. Resolve calculator method
            var method = Helper.Methods[operationNumber];

            var result = new Arithmetic().Add(firstNumber, secondNumber);
            // 1b. Execute the calculator method
            //var result = method.Invoke(firstNumber, secondNumber);

            // 1c. Result
            Messages.PrintResult(result);
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
    }
}
