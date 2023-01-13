using Calculator_Console.Configuration;
using Calculator_Console.Enums;
using Calculator_Console.UI;

// Configuration
Settings.ConfigureApplication(args);

// Workflow
ApplicationWorkflow();

static void ApplicationWorkflow()
{
    var userChoice = string.Empty;  // Stores user inputs. In case of invalid ones they will be used in user communication (error)
    var request = Request.Continue;

    while (ShouldContinueOn(request))
    {
        // Select mathematical operation
        if (!Feedback.GetValidOperation(ref userChoice, out var operationNumber, out request))
        {
            if (request == Request.Quit)
            {
                Feedback.Quit();
            }

            continue;
        }

        while (ShouldContinueOn(request))
        {
            // First number
            if (!Feedback.GetValidParameter(out var firstNumber, operationNumber, Number.First, out request))
            {
                if (request == Request.Cancel)
                {
                    break;
                }

                if (request == Request.Quit)
                {
                    Feedback.Quit();
                }

                continue;
            }

            while (ShouldContinueOn(request))
            {
                // Second number
                if (!Feedback.GetValidParameter(out var secondNumber, operationNumber, Number.Second, out request))
                {
                    if (request == Request.Cancel)
                    {
                        break;
                    }

                    if (request == Request.Quit)
                    {
                        Feedback.Quit();
                    }

                    continue;
                }


            }
        }
    }
}

static bool ShouldContinueOn(Request request)
{
    return request == Request.Continue;
}
