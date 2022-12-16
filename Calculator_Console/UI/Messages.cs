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
            Console.WriteLine("Select calculator operation:\n");

            // Options
            foreach (var method in Helper.Methods)
            {
                WriteColor($"{method.OrderNumber}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Name}");
            }

            // Errors
            if (!string.IsNullOrWhiteSpace(previousChoice))
            {
                Console.Write("\nPrevious: ");
                WriteLineColor($"{previousChoice}", ConsoleColor.DarkRed);
            }

            // Answer
            Console.Write("\nAnswer: ");
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
