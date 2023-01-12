using Calculator_Console.Constants;
using Calculator_Console.Helpers;

namespace Calculator_Console.UI
{
    internal static class Messages
    {
        /// <summary>
        /// Prompts user to select from variety of available calculator operations.
        /// </summary>
        /// <param name="userChoice">The input that user provided (will be initially empty).</param>
        internal static void SelectCalculatorOperation(string userChoice)
        {
            Console.Clear();

            // Header
            Console.Write("Select the given mathematical operation");
            // Confirm
            AndConfirm();

            // Options
            DisplaySelectableMathOptions();

            // Handle (potential) errors
            if (IsSelected(userChoice))
            {
                Console_WriteLineColor($"\nWrong option: {userChoice}", ConsoleColor.DarkRed);
            }

            // Answer
            Console.Write("\nOperation: ");
        }

        internal static void SelectNumber(ushort operationNumber, string whichNumber)
        {
            Console.Clear();

            // Reminder about selected method
            Console_WriteColor(Helper.Methods[operationNumber], ConsoleColor.White);
            // Quit or Cancel
            OrQuitOrCancel();
            // Confirm
            AndConfirm();
            
            // Answer
            Console.Write($"The {whichNumber} number: ");
        }

        /// <summary>
        /// Displays the selectable options for the user.
        /// </summary>
        private static void DisplaySelectableMathOptions()
        {
            // Operations
            foreach (var method in Helper.Methods)
            {
                Console_WriteColor($"{method.Key}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Value}");
            }

            // Quit option
            Console.Write("\n[");
            Console_WriteColor(Keys.Quit, ConsoleColor.Yellow);
            Console.WriteLine("]uit the application");
        }

        /// <summary>
        /// Adds reusable formula to Quit or Cancel the operation.
        /// </summary>
        private static void OrQuitOrCancel()
        {
            // Quit
            Console.Write(" or select [");
            Console_WriteColor(Keys.Quit, ConsoleColor.Yellow);
            Console.Write("]uit / [");
            // Cancel
            Console_WriteColor(Keys.Cancel, ConsoleColor.Yellow);
            Console.Write("]ancel");
        }

        /// <summary>
        /// Adds reusable formula about pressing Enter key to confirm the user choice.
        /// </summary>
        private static void AndConfirm()
        {
            Console.Write(" and press [");
            Console_WriteColor(Keys.Confirm, ConsoleColor.Yellow);
            Console.WriteLine("]:\n");
        }

        /// <summary>
        /// Determines whether the user typed something already.
        /// </summary>
        private static bool IsSelected(string previousChoice)
        {
            return !string.IsNullOrWhiteSpace(previousChoice);
        }

        /// <summary>
        /// Writes the specified text in color, using <see cref="Console.Write(string)"/> method.
        /// </summary>
        private static void Console_WriteColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        
        /// <summary>
        /// Writes the specified text in color, using <see cref="Console.WriteLine(string)"/> method.
        /// </summary>
        private static void Console_WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
