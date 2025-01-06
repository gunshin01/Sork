namespace Sork.Commands;

public class DanceCommand : BaseCommand
{
    private readonly UserInputOutput io;
    public DanceCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) => GetCommandFromInput(userInput) == "dance";
    public override CommandResult Execute()
    {
        io.WriteMessageLine("Dance, Dance, We're falling apart to half the time!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
