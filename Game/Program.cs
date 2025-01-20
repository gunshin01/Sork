using Microsoft.Extensions.DependencyInjection;
using Sork.Commands;
using Sork.World;
namespace Sork;
public class Program
{
    
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddSingleton<UserInputOutput>();
        services.AddSingleton<IUserInputOutput>(sp => sp.GetRequiredService<UserInputOutput>());
        services.AddSingleton<GameState>(sp => GameState.Create(sp.GetRequiredService<UserInputOutput>()));
        var commandTypes = typeof(ICommand).Assembly.GetTypes()
            .Where(t=> typeof(ICommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
        foreach (var commandType in commandTypes)
        {
            services.AddSingleton(typeof(ICommand), commandType);
        }
        var serviceProvider = services.BuildServiceProvider();
        var gameState = serviceProvider.GetRequiredService<GameState>();
        var commands = serviceProvider.GetServices<ICommand>().ToList();
        var io = serviceProvider.GetRequiredService<IUserInputOutput>();

        
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












