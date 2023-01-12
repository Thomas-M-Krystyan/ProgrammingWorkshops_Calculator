using Calculator_Console.Constants;
using Calculator_Console.Helpers;

namespace Calculator_Console.UI
{
    internal static class Messages
    {
        /// <summary>
        /// Prompts user to select from variety of available calculator operations.
        /// </summary>
        /// <param name="previousChoice">The previous choice.</param>
        internal static void SelectCalculatorOperation(string previousChoice)
        {
            Console.Clear();

            // Header
            Console.WriteLine("Select the given calculator operation and press [Enter]:\n");

            // Options
            DisplaySelectableOptions();

            if (IsSelected(previousChoice))
            {
                // Errors
                WriteLineColor($"\nWrong option: {previousChoice}", ConsoleColor.DarkRed);
            }

            // Answer
            Console.Write("\nOperation: ");
        }

        /// <summary>
        /// Displays the selectable options for the user.
        /// </summary>
        private static void DisplaySelectableOptions()
        {
            foreach (var method in Helper.Methods)
            {
                WriteColor($"{method.Key}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Value}");
            }

            WriteColor($"[{Keys.Quit}]", ConsoleColor.Yellow);
            Console.WriteLine(". Quit the application");
        }

        /// <summary>
        /// Determines whether the user typed something already.
        /// </summary>
        private static bool IsSelected(string previousChoice)
        {
            return !string.IsNullOrWhiteSpace(previousChoice);
        }

        #region Colorful output
        private static void WriteColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private static void WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        #endregion
    }
}
