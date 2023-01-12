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
            return value > 0 && value <= Helper.Methods.Count();
        }
    }
}
