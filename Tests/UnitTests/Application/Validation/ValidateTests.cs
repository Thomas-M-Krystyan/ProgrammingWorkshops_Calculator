using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using NUnit.Framework;
using Operations.Implementation;
using Operations.Interfaces;

namespace Calculator_ConsoleTests.Validation
{
    [TestFixture]
    internal class ValidateTests
    {
        private IValidationService _validator;

        [OneTimeSetUp]
        public void SetupTests()
        {
            IArithmetic arithmetic = new Arithmetic();
            IRegisterService register = new RegisterService(arithmetic);

            this._validator = new ValidationService(register);
        }

        [TestCase((ushort)0, false)]
        [TestCase((ushort)1, true)]
        [TestCase((ushort)3, true)]
        [TestCase((ushort)999, false)]
        public void CheckMethod_IsOperationExisting_ForValue_A_ReturnsExpectedResult(ushort value, bool expectedResult)
        {
            // Act
            bool actualResult = this._validator.IsOperationExisting(value);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
