namespace Sork;

public class LaughCommand : ICommand
{
    public bool Handles(string userInput)
    {
        return userInput == "lol";
    }
    

    public CommandResult Execute()
    {
        Console.WriteLine("You Laughed out Loud!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}