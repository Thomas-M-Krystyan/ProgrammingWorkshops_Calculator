using Calculator_Console.Configuration;
using Calculator_Console.UI;

// Configuration
Settings.ConfigureApplication(args);

// Workflow
ApplicationWorkflow();

static void ApplicationWorkflow()
{
    var userChoice = string.Empty;  // Stores user inputs. In case of invalid ones they will be used in user communication (error)
    ushort operationNumber = 0;
    double firstNumber = default;
    double secondNumber = default;

    while (true)
    {
        // Select mathematical operation
        if (Feedbacks.GetMathOperation(ref userChoice, ref operationNumber))
        {
            // First number
            while (true)
            {
                if (Feedbacks.GetMathParameter(ref firstNumber, operationNumber, "first"))
                {
                    // Second number
                    while (true)
                    {
                        if (Feedbacks.GetMathParameter(ref secondNumber, operationNumber, "second"))
                        {
                        }
                    }
                }
            }
        }

        // Quit
        Feedbacks.ProcessQuitRequest(userChoice);
    }
}
