using Calculator_Console.Services.Implementation;
using Calculator_Console.Services.Implementation.UI;
using Calculator_Console.Services.Interfaces;
using Calculator_Console.Services.Interfaces.UI;
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
            using IHost host = Host.CreateDefaultBuilder(arguments)
                .ConfigureServices((_, services) => services
                    // Logging
                    .ConfigureLogging()
                    // Services
                    .RegisterServives()
                    .BuildServiceProvider()  // Finalize preparation of services
                    // Workflow
                    .GetService<WorkflowService>().Start())  // Run the console calculator
                .Build();

            await host.RunAsync();
        }

        // --------------------------------
        // Configuration: Logging (console)
        // --------------------------------
        private static IServiceCollection ConfigureLogging(this IServiceCollection serviceCollection)
        {
            serviceCollection
                // Registers ILogger<T> service for console app
                .AddLogging(loggingBuilder =>
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace)
                                  .ClearProviders()
                                  .AddConsole())
                .BuildServiceProvider();

            return serviceCollection;
        }

        // -----------------------------------
        // Configuration: Registering services
        // -----------------------------------
        private static IServiceCollection RegisterServives(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                // Master startup service
                .AddSingleton<WorkflowService>()
                // Classical services (alphabetic order)
                .AddSingleton<IArithmetic, Arithmetic>()
                .AddSingleton<IFeedbackService, FeedbackService>()
                .AddSingleton<IMessagesService, MessagesService>()
                .AddSingleton<IRegisterService, RegisterService>()
                .AddSingleton<IValidationService, ValidationService>();
        }
    }
}
