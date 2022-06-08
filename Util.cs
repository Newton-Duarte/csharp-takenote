namespace TakeNote
{
    public static class Util
    {
        public static void CreateConsoleTitle(string title)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"---> [{title}] <---");
            Console.WriteLine("------------------------------");
        }

        public static void CreateColoredConsoleMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"---> {message}");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}