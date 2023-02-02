using Calculator_Console.Constants;
using Calculator_Console.Helpers;

namespace Calculator_Console.Validation
{
    internal static class Validate
    {
        /// <summary>
        /// Determines whether the provided input is a number.
        /// </summary>
        internal static bool IsInputNumeric(ref string userChoice, out ushort value)
        {
            userChoice = TranslateEmptyInput(userChoice);

            return ushort.TryParse(userChoice, out value);
        }

        /// <summary>
        /// Determines whether the provided input is a floating number (double).
        /// </summary>
        internal static bool IsInputDouble(ref string userChoice, out double value)
        {
            userChoice = TranslateEmptyInput(userChoice);

            return double.TryParse(userChoice, out value);
        }

        /// <summary>
        /// Recognizes the empty input (Enter, Tab, Space, etc.).
        /// </summary>
        private static string TranslateEmptyInput(string userChoice)
        {
            return userChoice switch
            {
                "" => "[Enter]",
                "\t" => "[Tab]",
                _ => string.IsNullOrWhiteSpace(userChoice) ? "[Space]" : userChoice
            };
        }

        /// <summary>
        /// Determines whether the given value is corresponding to the amount of existing calculator operations.
        /// </summary>
        internal static bool IsOperationExisting(ushort value)
        {
            return value > 0 && value <= Register.Methods.Count;
        }

        internal static bool IsQuitRequested(string userChoice)
        {
            return string.Equals(userChoice, Keybindings.Quit, StringComparison.OrdinalIgnoreCase);
        }

        internal static bool IsRestartRequested(string userChoice)
        {
            return string.Equals(userChoice, Keybindings.Cancel, StringComparison.OrdinalIgnoreCase);
        }
    }
}
