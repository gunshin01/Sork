namespace Sork.Commands;

public class SingCommand : BaseCommand
{
    private readonly UserInputOutput io;
    public SingCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) => GetCommandFromInput(userInput) == "sing";
    public override CommandResult Execute()
    {
        Console.WriteLine("I Love to sing! She recently confessed to me, by the way I have a recording of her lovely singing voice.");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}