using RPG.Data;
using RPG.Data.characters;
using RPG.Data.characters.helpers;
using RPG.Data.models;

namespace RPG.screens
{
    public class CharacterSelectScreen
    {
        private Hero? _hero;
        private const int maxPointsForDistribution = 3;

        public CharacterSelectScreen()
        {
            
        }

        public async Task RunAsync()
        {
            Console.Clear();
            Console.WriteLine("Choose character type:");

            var heroTypes = HeroActionsHelper.GetHeroTypes();
            for (int i = 0; i < heroTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {heroTypes[i].Name}");
            }

            string? choice = Console.ReadLine();
            while (!HeroActionsHelper.IsValidHeroTypeNumber(choice, heroTypes.Length))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                choice = Console.ReadLine();
            }

            int selectedIndex = (int.Parse(choice!)) - 1;
            Type selectedHeroType = heroTypes[selectedIndex];
            _hero = (Activator.CreateInstance(type: selectedHeroType) as Hero)!;

            var saveTask = Task.Run(() => HeroActionsHelper.SaveHeroToDatabaseAsync(_hero));

            Console.WriteLine($"Would you like to buff up your stats before starting?        (Limit: {maxPointsForDistribution} points total)");
            Console.Write("Response (Y/N): ");
            choice = Console.ReadLine();
            while (!HeroActionsHelper.IsValidStringInput(choice) || choice != "y" && choice != "n")
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                choice = Console.ReadLine();
            }

            if (choice.Equals("y"))
            {
                HeroActionsHelper.DistributePoints(_hero);

                try
                {
                    await saveTask;
                    await HeroActionsHelper.UpdateHeroInDatabaseAsync(_hero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while saving the updated hero: {ex.Message}");
                    Thread.Sleep(2000);
                }

            }
            
            try
            {
                await saveTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the hero: {ex.Message}");
            }
        }
    }
}
