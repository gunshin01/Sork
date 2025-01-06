namespace Sork;

public class DanceCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "dance";
    public CommandResult Execute()
    {
        Console.WriteLine("Dance, Dance, We're falling apart to half the time!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
