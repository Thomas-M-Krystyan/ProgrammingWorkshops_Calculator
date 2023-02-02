using Calculator_Console.UI.Implementation;
using Calculator_Console.UI.Interfaces;
using Calculator_Console.Workflow;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Operations.Implementation;
using Operations.Interfaces;

namespace Calculator_Console.Configuration
{
    internal static class Settings
    {
        /// <summary>
        /// Configures console application.
        /// </summary>
        internal static void ConfigureApplication(string[] arguments)
        {
            ConfigureDependencyInjection(arguments);
        }

        // ----------------------------------------
        // Configuration: Dependency Injection (DI)
        // ----------------------------------------
        private static async void ConfigureDependencyInjection(string[] arguments)
        {
            using var host = Host.CreateDefaultBuilder(arguments)
                .ConfigureServices((_, services) => services
                    // Logging
                    .ConfigureLogging()
                    // Services
                    .RegisterServives()
                    .BuildServiceProvider()
                    // Workflow
                    .GetService<Work>()
                    .Start())
                .Build();

            await host.RunAsync();
        }

        private static IServiceCollection RegisterServives(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                // Master startup service
                .AddSingleton<Work>()
                // Classical services
                .AddSingleton<IFeedbackService, Feedback>()
                .AddSingleton<IArithmetic, Arithmetic>();
        }

        // --------------------------------
        // Configuration: Logging (console)
        // --------------------------------
        private static IServiceCollection ConfigureLogging(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddLogging(loggingBuilder =>
                    loggingBuilder.SetMinimumLevel(LogLevel.Debug)
                                  .ClearProviders()
                                  .AddConsole())
                .BuildServiceProvider();

            return serviceCollection;
        }
    }
}
