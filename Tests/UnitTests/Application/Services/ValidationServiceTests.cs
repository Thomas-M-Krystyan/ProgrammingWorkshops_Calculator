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
