public class WhistleCommand : ICommand
{
    public bool Handles(string userInput) => userInput == "whistle";
    public CommandResult Execute()
    {
        Console.WriteLine("Come on somebody, why don't you run? Ol'Reds itching to have a little fun!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
    
}