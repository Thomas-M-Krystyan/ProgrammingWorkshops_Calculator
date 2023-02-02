using System.Reflection;
using Operations.Interfaces;

namespace Calculator_Console.Helpers
{
    internal static class Register
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
        internal static IDictionary<ushort , Func<double, double, double>> Methods { get; }

        /// <summary>
        /// Initializes the <see cref="Register"/> class.
        /// </summary>
        static Register()
        {
            Methods = GetArithmeticOperations();
        }

        /// <summary>
        /// Gets the collection of ordered available calculator operations.
        /// </summary>
        /// <returns>
        ///   Data format: (1, method()).
        /// </returns>
        private static IDictionary<ushort, Func<double, double, double>> GetArithmeticOperations()
        {
            ushort orderNumber = 1;
            
            return GetMethods().ToDictionary(_ =>
                // Key
                orderNumber++,
                // Value
                GetMethodDelegate);
        }

        /// <summary>
        /// Extracts all publicly defined methods from the given interface.
        /// </summary>
        /// <returns>Collection of methods meta data.</returns>
        private static IEnumerable<MethodInfo> GetMethods()
        {
            return typeof(IArithmetic).GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets the the delegate to the provided method.
        /// </summary>
        private static Func<double, double, double> GetMethodDelegate(MethodInfo method)
        {
            // Creates a specific delegate type for instance methods
            return (Func<double, double, double>)Delegate.CreateDelegate(typeof(Func<double, double, double>), null, method);
        }
    }
}
