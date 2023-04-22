using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using NUnit.Framework;
using Operations.Implementation;
using Operations.Interfaces;
using System.Collections.Generic;

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

        [TestCaseSource(nameof(GetNumericTestCases))]
        public void CheckMethod_IsInputNumeric_ForGivenValue_ReturnsExpectedResult((string Value, bool ExpectedResult) data)
        {
            // Act
            bool actualResult = this._validator.IsInputNumeric(ref data.Value, out _);

            // Assert
            Assert.That(actualResult, Is.EqualTo(data.Value is not "-5" and not "99999" && data.ExpectedResult));
        }

        [TestCaseSource(nameof(GetNumericTestCases))]
        public void CheckMethod_IsInputDouble_ForGivenValue_ReturnsExpectedResult((string Value, bool ExpectedResult) data)
        {
            // Act
            bool actualResult = this._validator.IsInputDouble(ref data.Value, out _);

            // Assert
            Assert.That(actualResult, Is.EqualTo(data.ExpectedResult));
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(3, true)]
        [TestCase(999, false)]
        public void CheckMethod_IsOperationExisting_ForGivenValue_ReturnsExpectedResult(int value, bool expectedResult)
        {
            // Act
            bool actualResult = this._validator.IsOperationExisting((ushort)value);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCaseSource(nameof(GetRequestsTestCases))]
        [TestCaseSource(nameof(GetQuitRequestsTestCases))]
        public void CheckMethod_IsQuitRequested_ForGivenValue_ReturnsExpectedResult((string Input, bool ExpectedResult) data)
        {
            // Act
            bool actualResult = this._validator.IsQuitRequested(data.Input);

            // Assert
            Assert.That(actualResult, Is.EqualTo(data.ExpectedResult));
        }

        [TestCaseSource(nameof(GetRequestsTestCases))]
        [TestCaseSource(nameof(GetRestartRequestsTestCases))]
        public void CheckMethod_IsRestartRequested_ForGivenValue_ReturnsExpectedResult((string Input, bool ExpectedResult) data)
        {
            // Act
            bool actualResult = this._validator.IsRestartRequested(data.Input);

            // Assert
            Assert.That(actualResult, Is.EqualTo(data.ExpectedResult));
        }

        private static IEnumerable<(string, bool)> GetNumericTestCases()
        {
            yield return ("", false);
            yield return (" ", false);
            yield return (null, false);
            yield return ("0", true);
            yield return ("-5", true);
            yield return ("99", true);
            yield return ("99999", true);
            yield return ("a", false);
            yield return ("$", false);
            yield return ("9-1-1", false);
            yield return ("\t", false);
            yield return ("\r\n", false);
            yield return ("标准号", false);
            yield return ("€.‚ƒ„…†‡ˆ‰Š‹Œ.Ž.", false);
        }

        private static IEnumerable<(string, bool)> GetRequestsTestCases()
        {
            yield return ("", false);
            yield return (" ", false);
            yield return (null, false);
            yield return ("5", false);
            yield return ("a", false);
        }

        private static IEnumerable<(string, bool)> GetQuitRequestsTestCases()
        {
            yield return ("q", true);
            yield return ("Q", true);
        }

        private static IEnumerable<(string, bool)> GetRestartRequestsTestCases()
        {
            yield return ("c", true);
            yield return ("C", true);
        }
    }
}
