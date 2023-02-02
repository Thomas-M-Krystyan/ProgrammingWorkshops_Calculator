using Calculator_Console.Constants;
using Calculator_Console.Enums;
using Calculator_Console.Extensions;
using Calculator_Console.Services.Interfaces;
using Calculator_Console.Services.Interfaces.UI;

namespace Calculator_Console.Services.Implementation.UI
{
    /// <inheritdoc cref="IMessagesService" />
    internal sealed class MessagesService : IMessagesService
    {
        private readonly IRegisterService _register;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagesService"/> class.
        /// </summary>
        public MessagesService(IRegisterService register)
        {
            this._register = register;
        }

        /// <inheritdoc cref="IMessagesService.SelectCalculatorOperation(string)" />
        public void SelectCalculatorOperation(string userChoice)
        {
            Console.Clear();

            // Header
            Console.Write("Select the given mathematical operation ");
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

        /// <inheritdoc cref="IMessagesService.SelectNumber(string, ushort, Number)" />
        public void SelectNumber(string userChoice, ushort operationNumber, Number whichNumber)
        {
            Console.Clear();

            // Reminder about selected method
            Console_WriteColor(this._register.Methods[operationNumber].Method.Name, ConsoleColor.White);
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

        /// <inheritdoc cref="IMessagesService.PrintResult(double)" />
        public void PrintResult(double result)
        {
            Console.Clear();

            // Result
            Console.Write("The result is: ");
            Console_WriteLineColor($"{result}\n", ConsoleColor.Green);

            // Continue or Quit
            Console.Write("Press any key to continue or ");
            Quit();
            Console.WriteLine(":");
        }

        #region Display methods
        /// <summary>
        /// Displays the selectable options for the user.
        /// </summary>
        private void DisplaySelectableMathOptions()
        {
            Console.Write("\n");

            // Operations
            foreach (KeyValuePair<ushort, Func<double, double, double>> method in this._register.Methods)
            {
                Console_WriteColor($"{method.Key}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Value.Method.Name}");
            }

            // Quit
            Console.Write("\n");
            Quit();
            Console.WriteLine(" the application");
        }

        /// <summary>
        /// Displays error message.
        /// </summary>
        private static void WrongInput(string userChoice)
        {
            Console_WriteLineColor($"\nWrong option: {userChoice}", ConsoleColor.DarkRed);
        }

        /// <summary>
        /// Adds reusable Quit or Cancel text to display.
        /// </summary>
        private static void OrQuitOrCancel()
        {
            // Quit
            Console.Write(" or select ");
            Quit();
            // Cancel
            Console.Write(" / [");
            Console_WriteColor(Keybindings.Cancel, ConsoleColor.Yellow);
            Console.Write("]ancel ");
        }

        /// <summary>
        /// Adds reusable Quit text to display.
        /// </summary>
        private static void Quit()
        {
            Console.Write("[");
            Console_WriteColor(Keybindings.Quit, ConsoleColor.Yellow);
            Console.Write("]uit");
        }

        /// <summary>
        /// Adds reusable press Enter to confirm text to display.
        /// </summary>
        private static void AndConfirm()
        {
            Console.Write("and press [");
            Console_WriteColor(Keybindings.Confirm, ConsoleColor.Yellow);
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
