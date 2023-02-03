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
        public double Add(double firstNumber, double secondNumber);

        /// <summary>
        /// Subtracts two numbers from each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (difference) of subtracting two numbers.</returns>
        public double Subtract(double firstNumber, double secondNumber);

        /// <summary>
        /// Multiplies two numbers by each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (product) of multiplying two numbers.</returns>
        public double Multiply(double firstNumber, double secondNumber);

        /// <summary>
        /// Divides two numbers by each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The result (quotient) of dividing two numbers.</returns>
        public double Divide(double firstNumber, double secondNumber);

        /// <summary>
        /// Returns the rest of dividing two numbers by each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The rest (modulation) after dividing two numbers.</returns>
        public double Modulo(double firstNumber, double secondNumber);

        /// <summary>
        /// Exponentiates the [x] number to the [y] power.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="power">The power.</param>
        /// <returns>The result (exponentation) of [x] number lifted to the [y] power.</returns>
        public double Power(double number, double power);
    }
}
