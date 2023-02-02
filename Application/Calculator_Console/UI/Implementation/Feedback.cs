using Calculator_Console.Enums;
using Calculator_Console.Helpers;
using Calculator_Console.UI.Interfaces;
using Calculator_Console.Validation;
using Microsoft.Extensions.Logging;
using Operations.Implementation;
using Operations.Interfaces;

namespace Calculator_Console.UI.Implementation
{
    /// <inheritdoc cref="IFeedbackService" />
    internal sealed class Feedback : IFeedbackService
    {
        // ---------------------------------------------
        // Remembered user choices
        // ---------------------------------------------
        private static readonly object Padlock = new();

        private static string _userChoice = string.Empty;
        private static string UserChoice
        {
            get
            {
                lock (Padlock)
                {
                    return _userChoice;
                }
            }

            set
            {
                lock (Padlock)
                {
                    _userChoice = value;
                }
            }
        }
        // ---------------------------------------------

        private readonly ILogger<Feedback> _logger;
        private readonly IArithmetic _arithmetic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Feedback"/> class.
        /// </summary>
        public Feedback(ILogger<Feedback> logger, IArithmetic arithmetic)
        {
            _logger = logger;
            _arithmetic = arithmetic;
        }

        /// <inheritdoc cref="IFeedbackService.GetValidOperation(out ushort)" />
        public Response GetValidOperation(out ushort operationNumber)
        {
            operationNumber = default;

            // 1. Ask for the math operation or cancellation
            Messages.SelectCalculatorOperation(UserChoice);
            UserChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(UserChoice))
            {
                return Response.Quit;
            }

            var currentChoice = UserChoice;  // NOTE: Workaround of rule that passing properties to ref parameters is forbidden

            var isSuccess =
                // 3. Validate if the user input is numeric
                Validate.IsInputNumeric(ref currentChoice, out operationNumber) &&
                // 4. Validate if there is corresponding math operation
                Validate.IsOperationExisting(operationNumber);
            
            UserChoice = currentChoice;

            if (isSuccess)
            {
                ClearAnswers();

                return Response.Continue;
            }
            else
            {
                return Response.KeepAsking;
            }
        }

        /// <inheritdoc cref="IFeedbackService.GetValidParameter(ushort, Number, out double)" />
        public Response GetValidParameter(ushort operationNumber, Number whichNumber, out double selectedValue)
        {
            selectedValue = double.NaN;

            // 1. Ask for the number or cancellation
            Messages.SelectNumber(UserChoice, operationNumber, whichNumber);
            UserChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(UserChoice))
            {
                return Response.Quit;
            }

            // 3. Restart option
            if (Validate.IsRestartRequested(UserChoice))
            {
                ClearAnswers();  // Reset the previous user choice (to clear "wrong choices" on the previous screen)

                return Response.StartAgain;
            }

            var currentChoice = UserChoice;  // NOTE: Workaround of rule that passing properties to ref parameters is forbidden

            // 4. Validate if the user input is floating point number
            var isSuccess = Validate.IsInputDouble(ref currentChoice, out selectedValue);

            UserChoice = currentChoice;

            if (isSuccess)
            {
                ClearAnswers();
            }
            else
            {
                selectedValue = double.NaN;
            }

            return Response.Continue;  // NOTE: Any value to be returned. In Work class there is a variable for aggregated results from
                                       //       both methods' invocations used to determine whether the workflow should continue or loop
        }

        /// <inheritdoc cref="IFeedbackService.PerformOperation(ushort, double, double)" />
        public Response PerformOperation(ushort operationNumber, double firstNumber, double secondNumber)
        {
            // 1. Calculation and showing the result
            try
            {
                // Resolve calculation method
                var method = Register.Methods[operationNumber];

                // Execute it
                //var result = method.Invoke(firstNumber, secondNumber);
                var result = new Arithmetic().Add(firstNumber, secondNumber);

                // SUCCESS: Print the result
                Messages.PrintResult(result);
            }
            catch (Exception exception)
            {
                // FAILURE: Print the error
                _logger.LogError(exception.Message);
            }

            // 2. Quit or restart option
            return Console.ReadKey().Key == ConsoleKey.Q
                ? Response.Quit
                : Response.StartAgain;
        }

        /// <summary>
        /// Clears cached user choice answers, for example to prevent showing error messages on
        /// the next screen (still using cached result) when the proper option was chosen before.
        /// </summary>
        private static void ClearAnswers()
        {
            UserChoice = string.Empty;
        }
    }
}
