using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using Moq;
using NUnit.Framework;
using Operations.Interfaces;
using System.Collections.Generic;

namespace Calculator_ConsoleTests.Helpers
{
    [TestFixture]
    public class HelperTests
    {
        private IRegisterService _register;

        [OneTimeSetUp]
        public void SetupTests()
        {
            Mock<IArithmetic> mockedArithmetic = new();

            this._register = new RegisterService(mockedArithmetic.Object);
        }

        [Test]
        public void CheckProperty_Methods_ReturnsExpectedMethodsDataCollection()
        {
            // Act
            IDictionary<ushort, System.Func<double, double, double>> methods = this._register.Methods;

            // Assert
            Assert.That(methods, Has.Count.EqualTo(4));
        }
    }
}
