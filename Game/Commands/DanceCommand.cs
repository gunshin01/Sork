using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using Sork.World;

namespace Sork.Commands;

public class DanceCommand : BaseCommand
{
    private readonly IUserInputOutput io;
    public DanceCommand(IUserInputOutput io)
    {
        this.io = io;
    }
    public override bool Handles(string userInput) 
    {
        var parmsLength = GetParametersFromInput(userInput).Length;
        return GetCommandFromInput(userInput) == "dance" && (parmsLength == 0 || parmsLength == 1);
    }
    
    public override CommandResult Execute(string userInput, GameState gameState)
    {
        var parameters = GetParametersFromInput(userInput);
        if (parameters.Length == 0)
        {
            io.WriteNoun("You");
            io.WriteMessageLine(" Dance!");
        }
        else 
        {
            io.WriteNoun("You");
            io.WriteMessage(" Dance with ");
            io.WriteNoun(parameters[0]);
            io.WriteMessageLine("!");
        }
        return new CommandResult { RequestExit = false, IsHandled = true };
    }
}
