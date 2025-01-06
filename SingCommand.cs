namespace Sork;

public class SingCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "sing";
    public CommandResult Execute()
    {
        Console.WriteLine("I Love to sing! She recently confessed to me, by the way I have a recording of her lovely singing voice.");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}