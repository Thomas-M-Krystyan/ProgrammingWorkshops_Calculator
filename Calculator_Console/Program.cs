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
            // Mathematical operation
            var operationNumber = Feedback.GetValidOperation();
            
            // The first number
            var firstNumber = Feedback.GetValidParameter(operationNumber, Number.First);
            
            // The second number
            var secondNumber = Feedback.GetValidParameter(operationNumber, Number.Second);

            // The result of calculation
            Feedback.PerformOperation(firstNumber, secondNumber, operationNumber);
        }
    }
}
