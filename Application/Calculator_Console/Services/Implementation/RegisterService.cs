using Calculator_Console.Services.Interfaces;
using Operations.Annodations;
using Operations.Interfaces;
using System.Reflection;

namespace Calculator_Console.Services.Implementation
{
    /// <inheritdoc cref="IRegisterService" />
    internal sealed class RegisterService : IRegisterService
    {
        private readonly IArithmetic _arithmetic;

        /// <inheritdoc cref="IRegisterService.Methods" />
        public IDictionary<ushort, MethodInfo> Methods { get; }

        private int _longestName = -1;

        int IRegisterService.GetLongestName
        {
            get
            {
                // Calculate the longest method name only once, since they will not change later
                if (this._longestName == -1)
                {
                    int longestName = default;

                    foreach (KeyValuePair<ushort, MethodInfo> method in Methods)
                    {
                        longestName = Math.Max(longestName, method.Value.Name.Length);
                    }

                    this._longestName = longestName;
                }

                return this._longestName;
            }
        }

        /// <summary>
        /// Initializes the <see cref="RegisterService"/> class.
        /// </summary>
        public RegisterService(IArithmetic arithmetic)
        {
            this._arithmetic = arithmetic;

            this.Methods = GetArithmeticOperations();
        }

        /// <summary>
        /// Gets the collection of ordered available calculator operations.
        /// </summary>
        /// <returns>
        ///   Data format: (1, methodInfo).
        /// </returns>
        private IDictionary<ushort, MethodInfo> GetArithmeticOperations()
        {
            ushort orderNumber = 1;

            return GetMethods()
                .ToDictionary(
                // Key
                keySelector: _ => orderNumber++,
                // Value
                elementSelector: methodInfo => methodInfo);
        }

        /// <summary>
        /// Extracts all publicly defined methods from the given interface.
        /// </summary>
        /// <returns>Collection of methods meta data.</returns>
        private IEnumerable<MethodInfo> GetMethods()
        {
            return this._arithmetic.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(IsCalculatorMethod);
        }

        private static bool IsCalculatorMethod(MethodInfo methodInfo)
        {
            return Attribute.IsDefined(methodInfo, typeof(Operation));
        }
    }
}
