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
            foreach (var method in Helper.Methods)
            {
                WriteColor($"{method.OrderNumber}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Name}");
            }

            // Errors
            if (!string.IsNullOrWhiteSpace(previousChoice))
            {
                WriteLineColor($"\nWrong option: {previousChoice}", ConsoleColor.DarkRed);
            }

            // Answer
            Console.Write("\nOption: ");
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
