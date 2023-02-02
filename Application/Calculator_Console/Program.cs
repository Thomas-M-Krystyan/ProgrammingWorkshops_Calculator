using Calculator_Console.Configuration;
using Calculator_Console.Enums;
using Calculator_Console.UI;

namespace Calculator_Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Configuration
            Settings.ConfigureApplication(args);

            // Workflow
            ApplicationWorkflow();
        }

        internal static void ApplicationWorkflow()
        {
            ushort operationNumber;
            double firstNumber;
            double secondNumber;

            // Mathematical operation
            while (!Feedback.GetValidOperation(out operationNumber)) { }

            // The first number
            while (!Feedback.GetValidParameter(operationNumber, Number.First, out firstNumber)) { }

            // The second number
            while (!Feedback.GetValidParameter(operationNumber, Number.Second, out secondNumber)) { }

            // The result of calculation
            Feedback.PerformOperation(operationNumber, firstNumber, secondNumber);
        }
    }
}
