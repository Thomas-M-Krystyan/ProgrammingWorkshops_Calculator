using Calculator_Console.Configuration;

namespace Calculator_Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // Configuration + Start the workflow
            Settings.ConfigureApplication(args);
        }
    }
}
