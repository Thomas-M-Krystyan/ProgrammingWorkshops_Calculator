using Calculator_Console.Constants;
using Calculator_Console.Enums;
using Calculator_Console.Extensions;
using Calculator_Console.Helpers;

namespace Calculator_Console.UI
{
    /// <summary>
    /// The messages used for communication with the user.
    /// </summary>
    internal static class Messages
    {
        /// <summary>
        /// Prompts user to select from variety of available calculator operations.
        /// </summary>
        /// <param name="userChoice">The input that user provided (initially will be empty).</param>
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
            if (userChoice != string.Empty)
            {
                WrongInput(userChoice);
            }

            // Answer
            Console.Write("\nOperation: ");
        }

        /// <summary>
        /// Selects the math parameter (number) required for further calculations.
        /// </summary>
        internal static void SelectNumber(string userChoice, ushort operationNumber, Number whichNumber)
        {
            Console.Clear();

            // Reminder about selected method
            Console_WriteColor(Helper.Methods[operationNumber].Method.Name, ConsoleColor.White);
            // Quit or Cancel
            OrQuitOrCancel();
            // Confirm
            AndConfirm();
            
            // Handle (potential) errors
            if (userChoice != string.Empty)
            {
                WrongInput(userChoice);
            }

            // Answer
            Console.Write($"\nThe {whichNumber.LowerCase()} number: ");
        }

        /// <summary>
        /// Prints the result.
        /// </summary>
        internal static void PrintResult(double result)
        {
            Console.Clear();

            // Result
            Console.WriteLine($"The result is: {result}\n");

            // Continue
            Console.Write("Press any key to continue or [");
            // Quit
            Console_WriteColor(Keys.Quit, ConsoleColor.Yellow);
            Console.WriteLine("]uit: ");
        }

        #region Display methods
        /// <summary>
        /// Displays the selectable options for the user.
        /// </summary>
        private static void DisplaySelectableMathOptions()
        {
            // Operations
            foreach (var method in Helper.Methods)
            {
                Console_WriteColor($"{method.Key}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Value.Method.Name}");
            }

            // Quit option
            Console.Write("\n[");
            Console_WriteColor(Keys.Quit, ConsoleColor.Yellow);
            Console.WriteLine("]uit the application");
        }

        /// <summary>
        /// Displays error message.
        /// </summary>
        private static void WrongInput(string userChoice)
        {
            Console_WriteLineColor($"\nWrong option: {userChoice}", ConsoleColor.DarkRed);
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
            Console.WriteLine("]:");
        }
        #endregion

        #region Color methods
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
        #endregion
    }
}
