using System;

namespace Operations.Annodations
{
    /// <summary>
    /// Custom attribute used to recognize only specific methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class Operation : Attribute
    {
    }
}
