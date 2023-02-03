using Calculator_Console.Enums;
using Calculator_Console.Services.Interfaces;

namespace Calculator_Console.Services.Implementation
{
    /// <summary>
    /// An entry-point main service responsible for starting the application workflow.
    /// </summary>
    internal class WorkflowService
    {
        private readonly IFeedbackService _feedbackService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowService"/> class.
        /// </summary>
        public WorkflowService(IFeedbackService feedbackService)
        {
            this._feedbackService = feedbackService;
        }

        /// <summary>
        /// Starts the workflow of the console version of calculator.
        /// </summary>
        internal void Start()
        {
            ushort operationNumber = default;
            double firstNumber = double.NaN;
            double secondNumber = double.NaN;

            // Mathematical operation
            Response result = Response.KeepAsking;

            while (KeepAsking(result))
            {
                result = this._feedbackService.GetValidOperation(out operationNumber);

                // Check special requests
                HandleQuit(result);
            }

            // The first and second number
            result = Response.KeepAsking;

            while (KeepAsking(result))
            {
                // NOTE: After refactor calls of both methods were simplified into a single while loop to not write 2x code that is 95% similar
                result = double.IsNaN(firstNumber)
                    ? this._feedbackService.GetValidParameter(operationNumber, Number.First, out firstNumber)
                    : this._feedbackService.GetValidParameter(operationNumber, Number.Second, out secondNumber);

                // Check special requests
                HandleQuit(result);
                HandleRestart(result);

                result = BothNumbersDefined(firstNumber, secondNumber)
                    ? Response.Continue
                    : Response.KeepAsking;
            }

            // The result of calculation
            result = this._feedbackService.PerformOperation(operationNumber, firstNumber, secondNumber);

            HandleQuit(result);
            HandleRestart(result);
        }

        #region Helper methods
        private static bool KeepAsking(Response response)
        {
            return response == Response.KeepAsking;
        }

        private static void HandleQuit(Response response)
        {
            if (response == Response.Quit)
            {
                Environment.Exit(0);
            }
        }

        private void HandleRestart(Response response)
        {
            if (response == Response.StartAgain)
            {
                Start();
            }
        }

        private static bool BothNumbersDefined(double firstNumber, double secondNumber)
        {
            return !double.IsNaN(firstNumber) && !double.IsNaN(secondNumber);
        }
        #endregion
    }
}
