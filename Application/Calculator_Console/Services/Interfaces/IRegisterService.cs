using Operations.Interfaces;
using System.Reflection;

namespace Calculator_Console.Services.Interfaces
{
    /// <summary>
    /// Scans the logic <see cref="IArithmetic"/> interface to map the available mathematical operations.
    /// </summary>
    internal interface IRegisterService
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
        internal IDictionary<ushort, MethodInfo> Methods { get; }

        internal int GetLongestName { get; }
    }
}
