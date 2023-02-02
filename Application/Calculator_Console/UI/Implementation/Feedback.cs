using Calculator_Console.Enums;
using Calculator_Console.Helpers;
using Calculator_Console.UI.Interfaces;
using Calculator_Console.Validation;
using Microsoft.Extensions.Logging;
using Operations.Implementation;

namespace Calculator_Console.UI.Implementation
{
    /// <inheritdoc cref="IFeedbackService" />
    internal sealed class Feedback : IFeedbackService
    {
        private static string _userChoice = string.Empty;

        private readonly ILogger<Feedback> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Feedback"/> class.
        /// </summary>
        public Feedback(ILogger<Feedback> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc cref="IFeedbackService.GetValidOperation(out ushort)" />
        public Response GetValidOperation(out ushort operationNumber)
        {
            // 1. Ask for the math operation or cancellation
            Messages.SelectCalculatorOperation(_userChoice);
            _userChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(_userChoice))
            {
                operationNumber = default;

                return Response.Quit;
            }

            var isSuccess =
                // 3. Validate if the user input is numeric
                Validate.IsInputNumeric(ref _userChoice, out operationNumber) &&
                // 4. Validate if there is corresponding math operation
                Validate.IsOperationExisting(operationNumber);

            if (isSuccess)
            {
                ClearAnswers();

                return Response.Continue;
            }
            else
            {
                operationNumber = default;

                return Response.KeepAsking;
            }
        }

        /// <inheritdoc cref="IFeedbackService.GetValidParameter(ushort, Number, out double)" />
        public Response GetValidParameter(ushort operationNumber, Number whichNumber, out double selectedValue)
        {
            selectedValue = double.NaN;

            // 1. Ask for the number or cancellation
            Messages.SelectNumber(_userChoice, operationNumber, whichNumber);
            _userChoice = Console.ReadLine();

            // 2. Quit option
            if (Validate.IsQuitRequested(_userChoice))
            {
                return Response.Quit;
            }

            // 3. Restart option
            if (Validate.IsRestartRequested(_userChoice))
            {
                ClearAnswers();  // Reset the previous user choice (to clear "wrong choices" on the previous screen)

                return Response.StartAgain;
            }

            // 4. Validate if the user input is floating point number
            var isSuccess = Validate.IsInputDouble(ref _userChoice, out selectedValue);

            if (isSuccess)
            {
                ClearAnswers();

                return Response.Continue;
            }
            else
            {
                selectedValue = double.NaN;

                return Response.KeepAsking;
            }
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
            _userChoice = string.Empty;
        }
    }
}
