using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using NUnit.Framework;
using Operations.Implementation;
using Operations.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace Calculator_ConsoleTests.Helpers
{
    [TestFixture]
    public class HelperTests
    {
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
            Assert.That(methods, Has.Count.EqualTo(12));
        }
    }
}
