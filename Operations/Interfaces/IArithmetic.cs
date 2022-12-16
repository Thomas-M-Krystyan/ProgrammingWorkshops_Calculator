namespace Operations.Interfaces
{
    /// <summary>
    /// The calculator mathematical operations.
    /// </summary>
    public interface IArithmetic
    {
        /// <summary>
        /// Adds two numbers to each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (sum) of adding two numbers.</returns>
        double Add(double firstNumber, double secondNumber);
        
        /// <summary>
        /// Subtracts two numbers from each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (difference) of subtracting two numbers.</returns>
        double Subtract(double firstNumber, double secondNumber);
        
        /// <summary>
        /// Multiplies two numbers by each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (product) of multiplying two numbers.</returns>
        double Multiply(double firstNumber, double secondNumber);
        
        /// <summary>
        /// Divides two numbers by each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (quotient) of dividing two numbers.</returns>
        double Divide(double firstNumber, double secondNumber);
    }
}
