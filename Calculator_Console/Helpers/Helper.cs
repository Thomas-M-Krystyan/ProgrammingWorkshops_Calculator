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
        /// The collection of methods data:
        ///   <list type="bullet">
        ///     <item>The order number of a method</item>
        ///     <item>The name of a method</item>
        ///   </list>
        /// </value>
        internal static IEnumerable<(int OrderNumber, string Name)> Methods { get; }

        /// <summary>
        /// Initializes the <see cref="Helper"/> class.
        /// </summary>
        static Helper()
        {
            Methods = GetArithmeticOperations().ToArray();
        }

        /// <summary>
        /// Populates the collection of available calculator operations.
        /// </summary>
        /// <returns>
        /// The collection of available operations with order numbers in the given format:
        ///
        /// <list type="bullet">
        ///   <item>(1, "Method A")</item>
        ///   <item>(2, "Method B")</item>
        /// </list>
        /// </returns>
        private static IEnumerable<(int, string)> GetArithmeticOperations()
        {
            var orderNumber = 1;

            return GetMethods().Select(method => (orderNumber++, method.Name));
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
