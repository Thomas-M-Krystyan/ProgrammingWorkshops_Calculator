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
            double module = firstNumber % secondNumber;

            return double.IsNaN(module) ? default : module;
        }

        [Operation("x /% y => T(imes) | R(est)")]
        /// <inheritdoc />
        public string Remainder(double firstNumber, double secondNumber)
        {
            string quotient = Divide(firstNumber, secondNumber);
            bool isSuccess = double.TryParse(quotient, out double parsedResult);

            return isSuccess
                ? parsedResult <= 0
                    ? "T:0"
                    : $"T:{Math.Floor(parsedResult)}|R:{Modulo(firstNumber, secondNumber)}"
                : quotient;
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
            return Power(number, 1 / root);
        }

        [Operation("x + y% of x")]
        /// <inheritdoc />
        public double Percent_Add(double number, double percent)
        {
            return Add(number, GetPercentFrom(number, percent));
        }

        [Operation("x - y% of x")]
        /// <inheritdoc />
        public double Percent_Subtract(double number, double percent)
        {
            return Subtract(number, GetPercentFrom(number, percent));
        }

        [Operation("y% from x")]
        /// <inheritdoc />
        public string Percent_From(double number, double percent)
        {
            return $"{GetPercentFrom(number, percent)}%";
        }

        [Operation("y is % of x")]
        /// <inheritdoc />
        public string Percent_Of(double firstNumber, double secondNumber)
        {
            return secondNumber == 0
                ? "Infinity"
                : $"{GetPercentOf(firstNumber, secondNumber)}%";
        }

        /// <summary>
        /// The formula to get the value of [y] percent from the given [x] number.
        /// <code>
        /// Example:
        /// 
        ///  100% from 10  is 10
        ///  10%  from 100 is 10
        ///  50%  from 200 is 100
        /// </code>
        /// </summary>
        private static double GetPercentFrom(double number, double percent)
        {
            return number * (percent / 100);
        }

        /// <summary>
        /// The formula to get the [y] percent from the value of the given [x] number.
        /// <code>
        /// Example:
        /// 
        ///  100 is 50%  of 200
        ///   50 is 25%  of 200
        ///  200 is 200% of 100
        /// </code>
        /// </summary>
        private static double GetPercentOf(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber * 100;
        }
    }
}
