using Operations.Annodations;
using System.Reflection;

namespace Calculator_Console.Extensions
{
    internal static class ReflexionExtensions
    {
        /// <summary>
        /// Gets the <see cref="Operation.Formula"/> from <see cref="Operation"/> attribute.
        /// </summary>
        internal static string GetFormula(this MethodInfo methodInfo)
        {
            return methodInfo.GetCustomAttribute<Operation>()?.Formula
                ?? $"This method does not have [{nameof(Operation)}] attribute";
        }
    }
}
