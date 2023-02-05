using NUnit.Framework;
using Operations.Implementation;
using System.Collections.Generic;

namespace OperationsTests.Implementation
{
    // ReSharper disable RedundantExplicitArrayCreation

    [TestFixture]
    public class ArithmeticTests
    {
        private Arithmetic _arithmeticOperations;

        [OneTimeSetUp]
        public void SetupTests()
        {
            this._arithmeticOperations = new Arithmetic();
        }

        [TestCaseSource(nameof(GetArithmeticCases_Add))]
        public void TestMethod_Add_ForGiven_A_B_ReturnsExpected_C(double[] arithmeticCases)
        {
            // Act
            double actualResult = this._arithmeticOperations.Add(arithmeticCases[0], arithmeticCases[1]);

            // Assert
            Assert.That(actualResult, Is.EqualTo(arithmeticCases[2]));
        }

        [TestCaseSource(nameof(GetArithmeticCases_Subtract))]
        public void TestMethod_Subtract_ForGiven_A_B_ReturnsExpected_C(double[] arithmeticCases)
        {
            // Act
            double actualResult = this._arithmeticOperations.Subtract(arithmeticCases[0], arithmeticCases[1]);

            // Assert
            Assert.That(actualResult, Is.EqualTo(arithmeticCases[2]));
        }

        [TestCaseSource(nameof(GetArithmeticCases_Multiply))]
        public void TestMethod_Multiply_ForGiven_A_B_ReturnsExpected_C(double[] arithmeticCases)
        {
            // Act
            double actualResult = this._arithmeticOperations.Multiply(arithmeticCases[0], arithmeticCases[1]);

            // Assert
            Assert.That(actualResult, Is.EqualTo(arithmeticCases[2]));
        }

        [TestCaseSource(nameof(GetArithmeticCases_Divide))]
        public void TestMethod_Divide_ForGiven_A_B_ReturnsExpected_C(double[] arithmeticCases)
        {
            // Act
            string actualResult = this._arithmeticOperations.Divide(arithmeticCases[0], arithmeticCases[1]);

            // Assert
            Assert.That(actualResult, Is.EqualTo(arithmeticCases[2].ToString()));
        }

        [TestCaseSource(nameof(GetArithmeticCases_Divide_ByZero))]
        public void TestMethod_Divide_ForGiven_A_0_ThrowsDivideByZeroException(double[] arithmeticCases)
        {
            // Arrange
            const string expectedMessage = "Cannot divide by 0!";

            // Act & Assert
            string actualResult = this._arithmeticOperations.Divide(arithmeticCases[0], arithmeticCases[1]);

            Assert.That(actualResult, Is.EqualTo(expectedMessage));
        }
        
        #region Test cases
        private static IEnumerable<double[]> GetArithmeticCases_Add()
        {
            yield return new double[] { 1, 2, 3 };            // + +
            yield return new double[] { 1.9997, 0.0003, 2 };  // + +
            yield return new double[] { -1, -2, -3 };         // - -
            yield return new double[] { 5, -3, 2 };           // + -
            yield return new double[] { -5, 3, -2 };          // - +
            yield return new double[] { 1, 0, 1 };            // + 0
            yield return new double[] { -1, 0, -1 };          // - 0
            yield return new double[] { 0, 1, 1 };            // 0 +
            yield return new double[] { 0, -1, -1 };          // 0 -
            yield return new double[] { 0, 0, 0 };            // 0 0
        }
        
        private static IEnumerable<double[]> GetArithmeticCases_Subtract()
        {
            yield return new double[] { 1, 2, -1 };           // + +
            yield return new double[] { 2.0003, 0.0003, 2 };  // + +
            yield return new double[] { -1, -2, 1 };          // - -
            yield return new double[] { 5, -3, 8 };           // + -
            yield return new double[] { -5, 3, -8 };          // - +
            yield return new double[] { 1, 0, 1 };            // + 0
            yield return new double[] { -1, 0, -1 };          // - 0
            yield return new double[] { 0, 1, -1 };           // 0 +
            yield return new double[] { 0, -1, 1 };           // 0 -
            yield return new double[] { 0, 0, 0 };            // 0 0
        }

        private static IEnumerable<double[]> GetArithmeticCases_Multiply()
        {
            yield return new double[] { 1, 2, 2 };           // + +
            yield return new double[] { 15.85, 7, 110.95 };  // + +
            yield return new double[] { -1, -2, 2 };         // - -
            yield return new double[] { 5, -3, -15 };        // + -
            yield return new double[] { -5, 3, -15 };        // - +
            yield return new double[] { 1, 0, 0 };           // + 0
            yield return new double[] { -1, 0, 0 };          // - 0
            yield return new double[] { 0, 1, 0 };           // 0 +
            yield return new double[] { 0, -1, 0 };          // 0 -
            yield return new double[] { 0, 0, 0 };           // 0 0
        }

        private static IEnumerable<double[]> GetArithmeticCases_Divide()
        {
            yield return new double[] { 1, 2, 0.5 };                   // + +
            yield return new double[] { -1, -2, 0.5 };                 // - -
            yield return new double[] { 5, -3, -1.6666666666666667 };  // + -
            yield return new double[] { -5, 3, -1.6666666666666667 };  // - +
            yield return new double[] { 0, 1, 0 };                     // 0 +
            yield return new double[] { 0, -1, 0 };                    // 0 -
        }

        private static IEnumerable<double[]> GetArithmeticCases_Divide_ByZero()
        {
            yield return new double[] {  1, 0 };  // + 0
            yield return new double[] { -1, 0 };  // - 0
            yield return new double[] {  0, 0 };  // 0 0
        }
        #endregion
    }
}
