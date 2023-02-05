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

        private ushort _longestName;
        private ushort _methodNumber;
        private int _methodNumberLength;

        /// <inheritdoc cref="IRegisterService.Methods" />
        public IDictionary<ushort, MethodInfo> Methods { get; }

        /// <inheritdoc cref="IRegisterService.GetLongestMethodName" />
        ushort IRegisterService.GetLongestMethodName
        {
            get => GetOrCalculateLongestName();
        }

        /// <inheritdoc cref="IRegisterService.GetLastMethodNoLength" />
        int IRegisterService.GetLastMethodNoLength
        {
            get => GetOrCalculateNumberLength();
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
            return GetMethods()
                .ToDictionary(
                    // Key
                    keySelector: _ => ++this._methodNumber,
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

        private ushort GetOrCalculateLongestName()
        {
            // Calculate the longest method name only once, since they will not change later
            if (this._longestName == default)
            {
                int longestName = default;

                foreach (KeyValuePair<ushort, MethodInfo> method in this.Methods)
                {
                    longestName = Math.Max(longestName, method.Value.Name.Length);
                }

                this._longestName = (ushort)longestName;
            }

            return this._longestName;
        }

        private int GetOrCalculateNumberLength()
        {
            if (this._methodNumberLength == default)
            {
                this._methodNumberLength = this._methodNumber.ToString().Length;
            }

            return this._methodNumberLength;
        }
    }
}
