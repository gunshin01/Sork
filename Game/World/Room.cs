namespace Sork.World;

public class Room
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Dictionary<string, Room> Exits { get; set; } = new Dictionary<string, Room>();
    public List<Item> Inventory { get; } = new();

    public string GetExitsList()
    {
        if (!Exits.Any())
            return "You see no exits, You're trapped!";
            
        var exitList = Exits
            .Select(exit => $"{exit.Key}")
            .ToList();
            
        return exitList.Count == 1 
            ? exitList[0]
            : $"{string.Join(", ", exitList.Take(exitList.Count - 1))} and {exitList.Last()}";
    }
}
