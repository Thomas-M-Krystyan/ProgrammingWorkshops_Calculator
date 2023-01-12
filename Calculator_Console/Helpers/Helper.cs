using System.Reflection;
using Operations.Interfaces;

namespace Calculator_Console.Helpers
{
    internal static class Helper
    {
        /// <summary>
        /// Gets the available calculator operations from <see cref="IArithmetic"/> interface.
        /// </summary>
        /// <value>
        ///   <list type="bullet">
        ///     <item>Key: The order number of a method (1, 2, 3...)</item>
        ///     <item>Value: The name of a method ("Add", "Subtract"...)</item>
        ///   </list>
        /// </value>
        internal static IDictionary<int , string> Methods { get; }

        /// <summary>
        /// Initializes the <see cref="Helper"/> class.
        /// </summary>
        static Helper()
        {
            Methods = GetArithmeticOperations();
        }

        /// <summary>
        /// Gets the collection of ordered available calculator operations.
        /// </summary>
        /// <returns>
        ///   Data in a dictionary format: (1, "Name").
        /// </returns>
        private static IDictionary<int, string> GetArithmeticOperations()
        {
            var orderNumber = 1;

            return GetMethods().ToDictionary(_ => orderNumber++, method => method.Name);
        }

        /// <summary>
        /// Extracts all publicly defined methods from the given interface.
        /// </summary>
        /// <returns>Collection of methods meta data.</returns>
        private static IEnumerable<MethodInfo> GetMethods()
        {
            return typeof(IArithmetic).GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
