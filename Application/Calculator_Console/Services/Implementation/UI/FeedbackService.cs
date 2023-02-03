using Calculator_Console.Enums;
using Calculator_Console.Services.Interfaces;
using Calculator_Console.Services.Interfaces.UI;
using Microsoft.Extensions.Logging;
using Operations.Interfaces;
using System.Reflection;

namespace Calculator_Console.Services.Implementation.UI
{
    /// <inheritdoc cref="IFeedbackService" />
    internal sealed class FeedbackService : IFeedbackService
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

        private readonly ILogger<FeedbackService> _logger;
        private readonly IArithmetic _arithmetic;
        private readonly IRegisterService _register;
        private readonly IMessagesService _messages;
        private readonly IValidationService _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackService"/> class.
        /// </summary>
        public FeedbackService(
            ILogger<FeedbackService> logger,
            IArithmetic arithmetic,
            IRegisterService register,
            IMessagesService messages,
            IValidationService validator)
        {
            this._logger = logger;
            this._arithmetic = arithmetic;
            this._register = register;
            this._messages = messages;
            this._validator = validator;
        }

        /// <inheritdoc cref="IFeedbackService.GetValidOperation(out ushort)" />
        public Response GetValidOperation(out ushort operationNumber)
        {
            operationNumber = default;

            // 1. Ask for the math operation or cancellation
            this._messages.SelectCalculatorOperation(UserChoice);
            UserChoice = Console.ReadLine();

            // 2. Quit option
            if (this._validator.IsQuitRequested(UserChoice))
            {
                return Response.Quit;
            }

            string currentChoice = UserChoice;  // NOTE: Workaround of rule that passing properties to ref parameters is forbidden

            bool isSuccess =
                // 3. Validate if the user input is numeric
                this._validator.IsInputNumeric(ref currentChoice, out operationNumber) &&
                // 4. Validate if there is corresponding math operation
                this._validator.IsOperationExisting(operationNumber);

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
            this._messages.SelectNumber(UserChoice, operationNumber, whichNumber);
            UserChoice = Console.ReadLine();

            // 2. Quit option
            if (this._validator.IsQuitRequested(UserChoice))
            {
                return Response.Quit;
            }

            // 3. Restart option
            if (this._validator.IsRestartRequested(UserChoice))
            {
                ClearAnswers();  // Reset the previous user choice (to clear "wrong choices" on the previous screen)

                return Response.StartAgain;
            }

            string currentChoice = UserChoice;  // NOTE: Workaround of rule that passing properties to ref parameters is forbidden

            // 4. Validate if the user input is floating point number
            bool isSuccess = this._validator.IsInputDouble(ref currentChoice, out selectedValue);

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
                // Resolve calculation method (based on user selection)
                MethodInfo method = this._register.Methods[operationNumber];

                // Execute it
                double result = (double)method.Invoke(this._arithmetic, new object[] { firstNumber, secondNumber });
                    
                // SUCCESS: Print the result
                this._messages.PrintResult(result);
            }
            // FAILURE: Print the error
            catch (Exception exception)
            {
                string message = exception.Message;

                if (exception is TargetInvocationException invocationException)
                {
                    message = invocationException.InnerException.Message;
                }

                #pragma warning disable CA2254  // Error message cannot be a static expression because this is a generic exception handler
                this._logger.LogError($"\n{message}");
                #pragma warning restore CA2254
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
