namespace Sork.World;

public class Room
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Dictionary<string, Room> Exits { get; set; } = new Dictionary<string, Room>();

    public string GetExitsList()
    {
        if (!Exits.Any())
            return "You see no exits, You're trapped!";
            
        var exitList = Exits
            .Select(exit => $"{exit.Key} to the {exit.Value.Name}")
            .ToList();
            
        return exitList.Count == 1 
            ? exitList[0]
            : $"{string.Join(", ", exitList.Take(exitList.Count - 1))} and {exitList.Last()}";
    }
}
