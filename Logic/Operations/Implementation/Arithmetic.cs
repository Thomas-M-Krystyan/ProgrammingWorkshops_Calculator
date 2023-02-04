using Operations.Annodations;
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

        [Operation("x + y%")]
        /// <inheritdoc />
        public double Percent_Add(double number, double percent)
        {
            return number + GetPercent(number, percent);
        }

        /// <summary>
        /// The formula to get a percent of the given number.
        /// </summary>
        private static double GetPercent(double number, double percent)
        {
            return number * (percent / 100);
        }
    }
}
