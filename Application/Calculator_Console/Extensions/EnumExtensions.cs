namespace Calculator_Console.Extensions
{
    internal static class EnumExtensions
    {
        /// <summary>
        /// Converts the given <see cref="Enum"/> into a lower case string.
        /// </summary>
        internal static string LowerCase(this Enum @enum)
        {
            return @enum.ToString().ToLower();
        }
    }
}
