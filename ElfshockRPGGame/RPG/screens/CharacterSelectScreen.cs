using Microsoft.EntityFrameworkCore;
using RPG.characters;
using RPG.characters.helpers;
using RPG.models;
using System.Reflection;

namespace RPG.screens
{
    public class CharacterSelectScreen
    {
        private const int maxPointsForDistribution = 3;

        public static void Run()
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
            Hero hero = (Activator.CreateInstance(type: selectedHeroType) as Hero)!;

            Console.WriteLine($"Would you like to buff up your stats before starting?        (Limit: {maxPointsForDistribution} points total");
            Console.WriteLine("Response (Y/N): ");
            choice = Console.ReadLine();
            while (!HeroActionsHelper.IsValidStringInput(choice) || choice != "y" || choice != "n")
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                choice = Console.ReadLine();
            }

            if (choice.Equals("y"))
            {
                HeroActionsHelper.DistributePoints(hero);
            }

            HeroActionsHelper.SaveHeroToDatabase(hero);
            Console.WriteLine($"Hero {hero.GetType().Name} created and saved to database.");
        }

        
    }
}
