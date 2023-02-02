using Calculator_Console.Validation;
using NUnit.Framework;

namespace Calculator_ConsoleTests.Validation
{
    [TestFixture]
    internal class ValidateTests
    {
        [TestCase((ushort)0, false)]
        [TestCase((ushort)1, true)]
        [TestCase((ushort)3, true)]
        [TestCase((ushort)999, false)]
        public void CheckMethod_IsOperationExisting_ForValue_A_ReturnsExpectedResult(ushort value, bool expectedResult)
        {
            // Act
            var actualResult = Validate.IsOperationExisting(value);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
