using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Interfaces;
using Moq;
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
        public void CheckProperty_GetLongestMethodName_ReturnsExpectedLengthOfTheLastMethodNumber()
        {
            // Arrange #1
            Mock<IRegisterService> registerMock = new();

            registerMock
                .SetupGet(mock => mock.Methods)
                .Returns(new Dictionary<ushort, MethodInfo>());

            // Act #1
            IDictionary<ushort, MethodInfo> actualMethods = registerMock.Object.Methods;
            ushort firstResult = registerMock.Object.GetLongestMethodName;

            // Assert #1
            Assert.Multiple(() =>
            {
                Assert.That(actualMethods, Is.Empty);  // Mocked register is using injected dummy IArithmetic service
                Assert.That(firstResult, Is.Zero);     // Generating the first result
            });

            // Arrange #2
            registerMock
                .SetupGet(mock => mock.Methods)
                .Returns(new Dictionary<ushort, MethodInfo> { { 0, null } });  // Modify the collection

            // Act #2
            actualMethods = registerMock.Object.Methods;
            ushort secondResult = registerMock.Object.GetLongestMethodName;  // Run the method again
            
            // Assert #2
            Assert.Multiple(() =>
            {
                Assert.That(actualMethods, Has.Count.EqualTo(1));
                Assert.That(secondResult, Is.Zero);  // The result should be cached even if the collection was modified
            });
        }

        [Test]
        public void CheckProperty_GetLastMethodNoLength_ReturnsExpectedLengthOfTheLastMethodNumber()
        {
            // Assert
            Assert.That(this._register.GetLastMethodNoLength, Is.EqualTo(CurrentMethodsAmount.ToString().Length));
        }
    }
}
