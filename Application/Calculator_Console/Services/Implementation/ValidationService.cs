using Calculator_Console.Constants;
using Calculator_Console.Services.Interfaces;

namespace Calculator_Console.Services.Implementation
{
    /// <inheritdoc cref="IValidationService" />
    internal class ValidationService : IValidationService
    {
        private readonly IRegisterService _register;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationService"/> class.
        /// </summary>
        public ValidationService(IRegisterService register)
        {
            this._register = register;
        }

        /// <inheritdoc cref="IValidationService.IsInputNumeric(ref string, out ushort)" />
        public bool IsInputNumeric(ref string userChoice, out ushort value)
        {
            userChoice = TranslateEmptyInput(userChoice);

            return ushort.TryParse(userChoice, out value);
        }

        /// <inheritdoc cref="IValidationService.IsInputDouble(ref string, out double)" />
        public bool IsInputDouble(ref string userChoice, out double value)
        {
            userChoice = TranslateEmptyInput(userChoice);

            return double.TryParse(userChoice, out value);
        }

        /// <inheritdoc cref="IValidationService.IsOperationExisting(ushort)" />
        public bool IsOperationExisting(ushort value)
        {
            return value > 0 && value <= this._register.Methods.Count;
        }

        /// <inheritdoc cref="IValidationService.IsQuitRequested(string)" />
        public bool IsQuitRequested(string userChoice)
        {
            return string.Equals(userChoice, Keybindings.Quit, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc cref="IValidationService.IsRestartRequested(string)" />
        public bool IsRestartRequested(string userChoice)
        {
            return string.Equals(userChoice, Keybindings.Cancel, StringComparison.OrdinalIgnoreCase);
        }

        #region Helper methods
        /// <summary>
        /// Recognizes the empty input (Enter, Tab, Space, etc.).
        /// </summary>
        private static string TranslateEmptyInput(string userChoice)
        {
            return userChoice switch
            {
                ""   => "[Enter]",
                "\t" => "[Tab]",
                _    => string.IsNullOrWhiteSpace(userChoice) ? "[Space]" : userChoice
            };
        }
        #endregion
    }
}
