using System;

namespace Operations.Annodations
{
    /// <summary>
    /// Custom attribute used to recognize only specific methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class Operation : Attribute
    {
        private string _formula;

        /// <summary>
        /// Gets or sets the math formula.
        /// </summary>
        public string Formula
        {
            get => this._formula;
            set => this._formula = $"(Formula: {(string.IsNullOrEmpty(value) ? "???" : value)})";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class.
        /// </summary>
        /// <param name="formula">The math formula ascribed to a specific calculator operation.</param>
        public Operation(string formula)
        {
            this.Formula = formula;
        }
    }
}
