using Calculator_Console.Helpers;

namespace Calculator_Console.Validation
{
    internal static class Validate
    {
        /// <summary>
        /// Determines whether the given value is corresponding to the amount of existing calculator operations.
        /// </summary>
        internal static bool IsOperationExisting(ushort value)
        {
            return value > 0 && value <= Helper.Methods.Count();
        }
    }
}
