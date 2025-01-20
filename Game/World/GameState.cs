namespace Sork.World;

public class GameState
{
    public required Player Player { get; set; }
    public required Room RootRoom { get; set; }

    public static GameState Create(IUserInputOutput io)
    {
        var tavern = new Room 
        { 
            Name = "Tavern", 
            Description = "You are in the tavern, it is dark, full of smoke and drunk patrons." 
        };
        var dungeon = new Room 
        { 
            Name = "Dungeon", 
            Description = "The dungeon is dark and cold." 
        };
        var cellar = new Room
        {
            Name = "Cellar",
            Description = "A damp cellar filled with barrels and a musty smell. You hear a whooshing sound behind you. The door has disappeared!"
        };
        var sword = new Item { Name = "Sword", Description = "A shiny sword." };
        tavern.Inventory.Add(sword);
        
        tavern.Exits.Add("right", dungeon);
        dungeon.Exits.Add("left", tavern);
        dungeon.Exits.Add("straight", cellar);

        // Update descriptions with exits
        tavern.Description = $"{tavern.Description} You look for an exit and see a door to the {tavern.GetExitsList()}.";
        dungeon.Description = $"{dungeon.Description} You look for an exit and see doors to the {dungeon.GetExitsList()}.";
        cellar.Description = $"{cellar.Description} {cellar.GetExitsList()}";

        io.WritePrompt($@"Navigation Commands:
- Look: See your surroundings
- Move [direction]: Move in specified direction

What is your name? ");

        string name = io.ReadInput();
        var player = new Player { Name = name, Location = tavern };
        return new GameState { Player = player, RootRoom = tavern };
    }
}