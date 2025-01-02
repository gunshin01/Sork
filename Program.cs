public class Program
{
    public static void Main(string[] args)
    {
        do
        {
            Console.Write(" > ");
            string input = Console.ReadLine();
            input = input.ToLower();
            input = input.Trim();
            if (input == "lol") { Console.WriteLine("You Laughed out Loud!"); }
            else if (input == "exit") { break; }
            else { Console.WriteLine("I can't do that Hal..."); }
        } while (true);
    }
}

