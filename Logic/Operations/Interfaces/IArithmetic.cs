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
        public string Divide(double firstNumber, double secondNumber);

        /// <summary>
        /// Returns the rest of dividing two numbers by each other.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The rest (modulation) after dividing two numbers.</returns>
        public double Modulo(double firstNumber, double secondNumber);

        /// <summary>
        /// <inheritdoc cref="Divide(double, double)"/> With eventual remainder.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns><inheritdoc cref="Divide(double, double)"/> With eventual remainder.</returns>
        public string Remainder(double firstNumber, double secondNumber);

        /// <summary>
        /// Exponentiates the [x] number to the [y] power.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="power">The power.</param>
        /// <returns>The result (exponentation) of [x] number lifted to the [y] power.</returns>
        public double Power(double number, double power);

        /// <summary>
        /// Gives the [y] root level for the [x] number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="root">The root level.</param>
        /// <returns>The result (rooting) of [x] number to the [y] level.</returns>
        public double Root(double number, double root);

        /// <summary>
        /// Adds the given [y] percent to the [x] number.
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent.</param>
        /// <returns>The [x] number increased by [y] percent.</returns>
        public double Percent_Add(double number, double percent);

        /// <summary>
        /// Subtracts the given [y] percentfrom the [x] number.
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent.</param>
        /// <returns>The [x] number decreased by [y] percent.</returns>
        public double Percent_Subtract(double number, double percent);

        /// <summary>
        /// Gets the [y] percent of the [x] number.
        /// </summary>
        /// <param name="number">The number</param>
        /// <param name="percent">The percent.</param>
        /// <returns>The [y] percent of the [x] number.</returns>
        public string Percent_From(double number, double percent);

        /// <summary>
        /// Checks what percent of the [x] number the [y] numbers is.
        /// </summary>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The percent of the [x] number from the [y] number.</returns>
        public string Percent_Of(double firstNumber, double secondNumber);
    }
}
