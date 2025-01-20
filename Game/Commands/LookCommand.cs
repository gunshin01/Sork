namespace Sork.Commands;
using Sork.World;
using System.Linq;

public class LookCommand : ICommand
{
    private readonly IUserInputOutput _io;

    public LookCommand(IUserInputOutput io)
    {
        _io = io;
    }

    public bool Handles(string input)
    {
        return input.Equals("look", StringComparison.OrdinalIgnoreCase);
    }

    public CommandResult Execute(string input, GameState gameState)
    {
        // Output the location description
        _io.WriteMessageLine(gameState.Player.Location.Description);
        
        // Output the inventory
        var inventory = gameState.Player.Location.Inventory.FirstOrDefault();
        if (inventory != null)
        {
            _io.WriteMessageLine($"You are carrying: {inventory.Name}");
        }

        return new CommandResult { IsHandled = true, RequestExit = false };
    }
}