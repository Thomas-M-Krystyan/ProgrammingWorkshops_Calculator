namespace Calculator_Console.Services.Interfaces
{
    /// <summary>
    /// Validates given criteria and returns <see langword="true"/> or <see langword="false"/> responses.
    /// </summary>
    internal interface IValidationService
    {
        /// <summary>
        /// Determines whether the provided input is a number.
        /// </summary>
        internal bool IsInputNumeric(ref string userChoice, out ushort value);

        /// <summary>
        /// Determines whether the provided input is a floating number (double).
        /// </summary>
        internal bool IsInputDouble(ref string userChoice, out double value);

        /// <summary>
        /// Determines whether the given value is corresponding to the amount of existing calculator operations.
        /// </summary>
        internal bool IsOperationExisting(ushort value);

        /// <summary>
        /// Determines whether QUIT operation was requested.
        /// </summary>
        internal bool IsQuitRequested(string userChoice);

        /// <summary>
        /// Determines whether RESTART operation was requested.
        /// </summary>
        internal bool IsRestartRequested(string userChoice);
    }
}
