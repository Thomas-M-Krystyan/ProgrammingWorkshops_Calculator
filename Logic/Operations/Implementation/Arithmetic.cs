using Operations.Annodations;
using Operations.Interfaces;
using System;

namespace Operations.Implementation
{
    /// <inheritdoc cref="IArithmetic" />
    public sealed class Arithmetic : IArithmetic
    {
        [Api]
        /// <inheritdoc />
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        
        [Api]
        /// <inheritdoc />
        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        
        [Api]
        /// <inheritdoc />
        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        
        [Api]
        /// <inheritdoc />
        public double Divide(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                // Replace the default exception message "Attempted to divide by 0"
                throw new DivideByZeroException("Cannot divide by 0!");
            }
            
            return firstNumber / secondNumber;
        }

        [Api]
        /// <inheritdoc />
        public double Modulo(double firstNumber, double secondNumber)
        {
            return firstNumber % secondNumber;
        }

        [Api]
        /// <inheritdoc />
        public double Power(double firstNumber, double secondNumber)
        {
            return Math.Pow(firstNumber, secondNumber);
        }
    }
}
