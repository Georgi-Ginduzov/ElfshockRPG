
namespace RPG
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            Game elfshock = new();
            await elfshock.RunAsync();
        }
    }
}
