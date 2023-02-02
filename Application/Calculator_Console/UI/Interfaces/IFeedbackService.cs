using Calculator_Console.Enums;

namespace Calculator_Console.UI.Interfaces
{
    /// <summary>
    /// Executes a certain operations and return a <see cref="Response"/> with operation or intermediate result.
    /// </summary>
    public interface IFeedbackService
    {
        /// <summary>
        /// Process the "mathematical operation" user input.
        /// </summary>
        public Response GetValidOperation(out ushort operationNumber);

        /// <summary>
        /// Collects the floating point input ("the number") required to process the selected mathematical operation.
        /// </summary>
        public Response GetValidParameter(ushort operationNumber, Number whichNumber, out double selectedValue);

        /// <summary>
        /// Performs the specific math operation with given parameters (numbers).
        /// </summary>
        public Response PerformOperation(ushort operationNumber, double firstNumber, double secondNumber);
    }
}
