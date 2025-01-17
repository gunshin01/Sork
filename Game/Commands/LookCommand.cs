namespace Sork.Commands;
using Sork.World;
public class LookCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public LookCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput)
    {
        return GetCommandFromInput(userInput) == "look";
    }
    public override CommandResult Execute(string userInput, GameState gameState)
    {
        io.WriteMessageLine(gameState.Player.Location.Description);
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}