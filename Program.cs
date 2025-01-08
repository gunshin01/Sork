using Sork.Commands;
using Sork.World;
namespace Sork;
public class Program
{
    public static void Main(string[] args)
    {
        UserInputOutput io = new UserInputOutput();
        var gameState = GameState.Create(io);
        ICommand lol = new LaughCommand(io);
        ICommand exit = new ExitCommand(io);
        ICommand dance = new DanceCommand(io);
        ICommand sing = new SingCommand(io);
        ICommand whistle = new WhistleCommand(io);
        ICommand move = new MoveCommand(io);
        ICommand look = new LookCommand(io);
        List<ICommand> commands = new List<ICommand> { lol, exit, dance, sing, whistle, move, look };
        
        do
        {
            io.WritePrompt(" > ");
            string input = io.ReadInput();
            input = input.ToLower();

            var result = new CommandResult{ RequestExit = false, IsHandled = false };
            var handled = false;
            foreach (var command in commands)
            {
                if (command.Handles(input)) 
                { 
                    handled = true;
                    result = command.Execute(input, gameState);
                    if(result.RequestExit){ break; } 
                    
                }
            }
            if (!handled) { io.WriteMessageLine($"I can't do that {gameState.Player.Name}..."); }
            if (result.RequestExit) { break; }
        } while (true);
    }
}

public class UserInputOutput
{
    public void WritePrompt(string prompt) 
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write(prompt);
        Console.ResetColor();
    }
    public void WriteMessage(string message) 
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(message);
        Console.ResetColor();

    }
    public void WriteNoun(string noun) 
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(noun);
        Console.ResetColor();
    }
    public void WriteMessageLine(string message) 
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public string ReadInput() 
    {
        return Console.ReadLine().Trim();
    }
    public string ReadKey() 
    {
        return Console.ReadKey().KeyChar.ToString();
    }
}










