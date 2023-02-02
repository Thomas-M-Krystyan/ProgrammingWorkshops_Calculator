using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace Calculator_ConsoleTests.Validation
{
    [TestFixture]
    internal class ValidateTests
    {
        private IValidationService _validator;

        [OneTimeSetUp]
        public void SetupTests()
        {
            Mock<IRegisterService> mockedRegister = new();

            this._validator = new ValidationService(mockedRegister.Object);
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
