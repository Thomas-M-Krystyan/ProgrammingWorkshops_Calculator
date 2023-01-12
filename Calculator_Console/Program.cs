using Calculator_Console.Configuration;
using Calculator_Console.UI;
using Calculator_Console.Validation;

// Configuration
Settings.ConfigureApplication(args);

// Workflow
ApplicationWorkflow();

static void ApplicationWorkflow()
{
    var userChoice = string.Empty;  // Stores user inputs. In case of invalid ones they will be used in user communication (error)
    double firstNumber = default;
    double secondNumber = default;

    while (true)
    {
        // 1. Ask for calculator operation
        Messages.SelectCalculatorOperation(userChoice);
        userChoice = Console.ReadLine();

        // 2. Validate if the user input is numeric
        if (!Validate.IsInputNumeric(ref userChoice, out var value)) { continue; }

        // 3. Validate if there is such calculator operation
        if (!Validate.IsOperationExisting(value)) { continue; }

        // 4. Ask for the first input number
        while (true)
        {
            Console.Write("First number: ");
            userChoice = Console.ReadLine();

            if (!double.TryParse(userChoice, out firstNumber)) { continue; }

            break;
        }

        break;
    }
}
