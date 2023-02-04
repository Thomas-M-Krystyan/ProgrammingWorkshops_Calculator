﻿using Operations.Annodations;
using Operations.Interfaces;
using System;

namespace Operations.Implementation
{
    /// <inheritdoc cref="IArithmetic" />
    public sealed class Arithmetic : IArithmetic
    {
        [Operation]
        /// <inheritdoc />
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        
        [Operation]
        /// <inheritdoc />
        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        
        [Operation]
        /// <inheritdoc />
        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        
        [Operation]
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

        [Operation]
        /// <inheritdoc />
        public double Modulo(double firstNumber, double secondNumber)
        {
            return firstNumber % secondNumber;
        }

        [Operation]
        /// <inheritdoc />
        public double Power(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
