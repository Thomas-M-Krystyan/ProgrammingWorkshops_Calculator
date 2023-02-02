using Operations.Interfaces;
using System;

namespace Operations.Implementation
{
    /// <inheritdoc cref="IArithmetic" />
    public sealed class Arithmetic : IArithmetic
    {
        /// <inheritdoc />
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        
        /// <inheritdoc />
        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        
        /// <inheritdoc />
        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        
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
    }
}
