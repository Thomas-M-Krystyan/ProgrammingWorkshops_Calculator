using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using NUnit.Framework;
using Operations.Implementation;
using Operations.Interfaces;

namespace Calculator_ConsoleTests.Services
{
    [TestFixture]
    internal class ValidationServiceTests
    {
        private IValidationService _validator;

        [OneTimeSetUp]
        public void SetupTests()
        {
            IArithmetic arithmetic = new Arithmetic();
            IRegisterService register = new RegisterService(arithmetic);

            this._validator = new ValidationService(register);
        }

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase(null, false)]
        [TestCase("0", true)]
        [TestCase("-5", false)]  // Only positive numbers are expected (ushort)
        [TestCase("99", true)]
        [TestCase("65536", false)]  // Too large number; > 65535 (ushort)
        [TestCase("a", false)]
        [TestCase("$", false)]
        [TestCase("9-1-1", false)]
        [TestCase("\t", false)]
        [TestCase("\r\n", false)]
        [TestCase("€.‚ƒ„…†‡ˆ‰Š‹Œ.Ž.", false)]
        public void CheckMethod_IsInputNumeric_ForValue_A_ReturnsExpectedResult(string value, bool expectedResult)
        {
            // Act
            bool actualResult = this._validator.IsInputNumeric(ref value, out _);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(3, true)]
        [TestCase(999, false)]
        public void CheckMethod_IsOperationExisting_ForValue_A_ReturnsExpectedResult(int value, bool expectedResult)
        {
            // Act
            bool actualResult = this._validator.IsOperationExisting((ushort)value);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
