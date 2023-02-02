namespace Calculator_Console.Enums
{
    /// <summary>
    /// The application workflow requests.
    /// </summary>
    internal enum Response
    {
        /// <summary>
        /// Failure: Continue asking user about the certain input.
        /// </summary>
        KeepAsking,

        /// <summary>
        /// Success: Move forward.
        /// </summary>
        Continue,

        /// <summary>
        /// Request: Restart the application workflow.
        /// </summary>
        StartAgain,

        /// <summary>
        /// Request: Stops the current workflow and quit the application.
        /// </summary>
        Quit
    }
}
