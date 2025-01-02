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
            else if (input == "dance") { Console.WriteLine("Dance, Dance, We're falling apart to half the time!"); }
            else if (input == "sing") { Console.WriteLine("I Love to sing! She recently confessed to me, by the way I have a recording of her lovely singing voice."); }
            else if (input == "whistle") { Console.WriteLine("Come on somebody, why don't you run? Ol'Reds itching to have a little fun!"); }
            else { Console.WriteLine("I can't do that Hal..."); }
        } while (true);
    }
}

