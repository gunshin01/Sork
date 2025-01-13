namespace Sork.Commands;
using Sork.World;
public class WhistleCommand : BaseCommand
{   
    private readonly UserInputOutput io;
    public WhistleCommand(UserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) 
    {
        return GetCommandFromInput(userInput) == "whistle";
    }
    public override CommandResult Execute(string userInput, GameState gameState)
    {
        io.WriteMessageLine("Come on somebody, why don't you run? Ol'Reds itching to have a little fun!");
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
    
}