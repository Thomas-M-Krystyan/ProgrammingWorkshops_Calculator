﻿using Calculator_Console.Constants;
using Calculator_Console.Enums;
using Calculator_Console.Extensions;
using Calculator_Console.Services.Interfaces;
using System.Reflection;

namespace Calculator_Console.Services.Implementation
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
        void IMessagesService.SelectCalculatorOperation(string userChoice)
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
        void IMessagesService.SelectNumber(string userChoice, ushort operationNumber, Number whichNumber)
        {
            Console.Clear();

            // Reminder about selected method
            Console_WriteColor(this._register.Methods[operationNumber].Name, ConsoleColor.White);
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
            Console.Write($"\nThe {whichNumber.LowerCase()} equation parameter: ");
        }

        /// <inheritdoc cref="IMessagesService.PrintResult(double)" />
        void IMessagesService.PrintResult(object result)
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
            foreach (KeyValuePair<ushort, MethodInfo> method in this._register.Methods)
            {
                Console_WriteColor($"{GetNumberSeparator(method.Key)}{method.Key}", ConsoleColor.Yellow);
                Console.WriteLine($". {method.Value.Name}{GetNameSeparator(method.Value)}{method.Value.GetFormula()}");
            }

            // Quit
            Console.Write("\n");
            Quit();
            Console.WriteLine(" the application");
        }

        /// <summary>
        /// Gets the smart tabularization to indent all method numbers to the period character.
        /// <code>
        /// Example:
        /// 
        ///   1. Method1
        ///  15. Method2
        /// </code>
        /// </summary>
        private string GetNumberSeparator<T>(T number)
        {
            int lastNumberLength = this._register.GetLastMethodNoLength;
            int currentNumberLength = number.ToString().Length;

            return currentNumberLength == lastNumberLength
                ? string.Empty
                : new string(' ', lastNumberLength - currentNumberLength);
        }

        /// <summary>
        /// Gets the smart tabularization to inline all formulas in one column.
        /// <code>
        /// Example:
        /// 
        ///  Add      (Formula...)
        ///  Subtract (Formula...)
        /// </code>
        /// </summary>
        private string GetNameSeparator(MethodInfo methodInfo)
        {
            int longestMethodName = this._register.GetLongestMethodName;

            return methodInfo.Name.Length == longestMethodName
                ? " "
                : new string(' ', longestMethodName - methodInfo.Name.Length + 1);
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
