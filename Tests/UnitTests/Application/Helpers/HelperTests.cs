using System.Linq;
using Calculator_Console.Helpers;
using NUnit.Framework;

namespace Calculator_ConsoleTests.Helpers
{
    [TestFixture]
    public class HelperTests
    {
        [Test]
        public void CheckProperty_Methods_ReturnsExpectedMethodsDataCollection()
        {
            // Act
            var methods = Register.Methods;

            // Assert
            Assert.That(methods.Count(), Is.EqualTo(4));
        }
    }
}
