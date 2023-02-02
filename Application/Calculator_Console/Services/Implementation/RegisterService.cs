using Calculator_Console.Services.Interfaces;
using Operations.Interfaces;
using System.Reflection;

namespace Calculator_Console.Services.Implementation
{
    /// <inheritdoc cref="IRegisterService" />
    internal sealed class RegisterService : IRegisterService
    {
        private readonly IArithmetic _arithmetic;

        /// <inheritdoc cref="IRegisterService.Methods" />
        public IDictionary<ushort, Func<double, double, double>> Methods { get; private set; }

        /// <summary>
        /// Initializes the <see cref="RegisterService"/> class.
        /// </summary>
        public RegisterService(IArithmetic arithmetic)
        {
            this._arithmetic = arithmetic;

            Methods = GetArithmeticOperations();
        }

        /// <summary>
        /// Gets the collection of ordered available calculator operations.
        /// </summary>
        /// <returns>
        ///   Data format: (1, method()).
        /// </returns>
        private IDictionary<ushort, Func<double, double, double>> GetArithmeticOperations()
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
        private IEnumerable<MethodInfo> GetMethods()
        {
            return this._arithmetic.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// Gets the the delegate to the provided method.
        /// </summary>
        private Func<double, double, double> GetMethodDelegate(MethodInfo method)
        {
            var x = method;

            // Creates a specific delegate type for instance methods
            return (Func<double, double, double>)Delegate.CreateDelegate(typeof(Func<double, double, double>), this._arithmetic, method);
        }
    }
}
