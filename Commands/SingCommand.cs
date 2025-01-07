namespace Sork.Commands;
using Sork.World;
public class SingCommand : BaseCommand
{
    private readonly UserInputOutput io;
    public SingCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) 
    {
        return GetCommandFromInput(userInput) == "sing";
    }
    public override CommandResult Execute(string userInput, GameState gameState)
    {
        io.WriteMessageLine("I Love to sing! She recently confessed to me, by the way I have a recording of her lovely singing voice.");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}