namespace RPG.screens
{
    public class ExitScreen
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Exiting the game. Goodbye!");
            Environment.Exit(0);
        }
    }
}
