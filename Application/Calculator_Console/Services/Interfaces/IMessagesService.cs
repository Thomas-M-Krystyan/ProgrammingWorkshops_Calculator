using Calculator_Console.Enums;

namespace Calculator_Console.Services.Interfaces
{
    /// <summary>
    /// The messages used for communication with the user.
    /// </summary>
    internal interface IMessagesService
    {
        /// <summary>
        /// Prompts user to select from variety of available calculator operations.
        /// </summary>
        /// <param name="userChoice">The input that user provided (initially will be empty).</param>
        internal void SelectCalculatorOperation(string userChoice);

        /// <summary>
        /// Selects the math parameter (number) required for further calculations.
        /// </summary>
        internal void SelectNumber(string userChoice, ushort operationNumber, Number whichNumber);

        /// <summary>
        /// Prints the result.
        /// </summary>
        internal void PrintResult(object result);
    }
}
