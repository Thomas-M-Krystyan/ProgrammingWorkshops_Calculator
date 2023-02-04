﻿using Operations.Annodations;
using Operations.Interfaces;
using System;

namespace Operations.Implementation
{
    /// <inheritdoc cref="IArithmetic" />
    public sealed class Arithmetic : IArithmetic
    {
        [Operation("x + y")]
        /// <inheritdoc />
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        
        [Operation("x - y")]
        /// <inheritdoc />
        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        
        [Operation("x * y")]
        /// <inheritdoc />
        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        
        [Operation("x / y")]
        /// <inheritdoc />
        public string Divide(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                // Replace the exception by a message
                return "Cannot divide by 0!";
            }

            string quotient = (firstNumber / secondNumber).ToString();

            return quotient.Equals("-0") ? "0" : quotient;
        }

        [Operation("x % y")]
        /// <inheritdoc />
        public double Modulo(double firstNumber, double secondNumber)
        {
            return firstNumber % secondNumber;
        }

        [Operation("x /% y => T(imes) | R(est)")]
        /// <inheritdoc />
        public string Remainder(double firstNumber, double secondNumber)
        {
            return $"T:{Math.Floor(firstNumber / secondNumber)}|R:{firstNumber % secondNumber}";
        }

        [Operation("x^y")]
        /// <inheritdoc />
        public double Power(double number, double power)
        {
            return Math.Pow(number, power);
        }

        [Operation("y√x")]
        /// <inheritdoc />
        public double Root(double number, double root)
        {
            return Math.Pow(number, 1 / root);
        }

        [Operation("x + y% of x")]
        /// <inheritdoc />
        public double Percent_Add(double number, double percent)
        {
            return Add(number, Percent_Get(number, percent));
        }

        [Operation("x - y% of x")]
        /// <inheritdoc />
        public double Percent_Subtract(double number, double percent)
        {
            return Subtract(number, Percent_Get(number, percent));
        }

        [Operation("y% of x")]
        /// <inheritdoc />
        public double Percent_Get(double number, double percent)
        {
            return number * (percent / 100);
        }
    }
}
