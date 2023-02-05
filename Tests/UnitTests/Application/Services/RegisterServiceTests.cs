using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using NUnit.Framework;
using Operations.Implementation;
using Operations.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace Calculator_ConsoleTests.Services
{
    [TestFixture]
    public class RegisterServiceTests
    {
        private const int CurrentMethodsAmount = 12;

        private IRegisterService _register;

        [OneTimeSetUp]
        public void SetupTests()
        {
            IArithmetic arithmetic = new Arithmetic();

            this._register = new RegisterService(arithmetic);
        }

        [Test]
        public void CheckProperty_Methods_ReturnsExpectedMethodsDataCollection()
        {
            // Act
            IDictionary<ushort, MethodInfo> methods = this._register.Methods;

            // Assert
            Assert.That(methods, Has.Count.EqualTo(CurrentMethodsAmount));
        }

        [Test]
        public void CheckProperty_GetLastMethodNoLength_ReturnsExpectedLengthOfTheLastMethodNumber()
        {
            // Assert
            Assert.That(this._register.GetLastMethodNoLength, Is.EqualTo(CurrentMethodsAmount.ToString().Length));
        }
    }
}
