using Microsoft.EntityFrameworkCore;
using RPG.models;
using System.Reflection;

namespace RPG.characters.helpers
{
    public static class HeroActionsHelper
    {
        private const int maxPointsForDistribution = 3;
        public static Type[] GetHeroTypes() => Assembly.GetAssembly(typeof(Hero))
                           .GetTypes()
                           .Where(t => t.IsSubclassOf(typeof(Hero)) && !t.IsAbstract)
                           .ToArray();

        public static void DistributePoints(Hero hero)
        {
            int pointsInput;
            int remainingPoints = maxPointsForDistribution;

            Console.WriteLine("Remaining points: " + maxPointsForDistribution);

            Console.WriteLine("Add to Strength: ");

            string? input = Console.ReadLine();
            pointsInput = int.TryParse(input, out int result) ? result : -1;

            while (!IsValidPointsInput(pointsInput, remainingPoints))
            {
                input = Console.ReadLine();
                pointsInput = int.TryParse(input, out result) ? result : -1;
            }

            if (pointsInput > 0)
            {
                hero.Strength += pointsInput;
                remainingPoints -= pointsInput;

                if (remainingPoints == 0)
                {
                    hero.Setup();
                    return;
                }
            }


            Console.WriteLine("Add to Agility: ");
            input = Console.ReadLine();
            pointsInput = int.TryParse(input, out result) ? result : -1;

            while (!IsValidPointsInput(pointsInput, remainingPoints))
            {
                input = Console.ReadLine();
                pointsInput = int.TryParse(input, out result) ? result : -1;
            }

            if (pointsInput > 0)
            {
                hero.Agility += pointsInput;
                remainingPoints -= pointsInput;

                if (remainingPoints == 0)
                {
                    hero.Setup();
                    return;
                }
            }


            Console.WriteLine("Add to Intelligence: ");
            input = Console.ReadLine();
            pointsInput = int.TryParse(input, out result) ? result : -1;

            while (!IsValidPointsInput(pointsInput, remainingPoints))
            {
                input = Console.ReadLine();
                pointsInput = int.TryParse(input, out result) ? result : -1;
            }

            if (pointsInput > 0)
            {
                hero.Intelligence += pointsInput;
                hero.Setup();
            }
        }

        public static void SaveHeroToDatabase(Hero hero)
        {
            using var context = new GameContext(new DbContextOptions<GameContext>());
            var heroEntity = new HeroEntity
            {
                Id = hero.Id,
                Type = hero.GetType().Name,
                Strength = hero.Strength,
                Agility = hero.Agility,
                Intelligence = hero.Intelligence,
                Range = hero.Range,
                Symbol = hero.Symbol,
                Health = hero.Health,
                Mana = hero.Mana,
                Damage = hero.Damage,
                CreationTime = hero.CreationTime
            };

            context.Heroes.Add(heroEntity);
            context.SaveChanges();
        }


        public static bool IsValidPointsInput(int input, int remainingPoints) => input >= 0 && input <= remainingPoints;
        public static bool IsValidStringInput(string? input) => !string.IsNullOrEmpty(input) && input != " ";
        public static bool IsValidHeroTypeNumber(string? input, int heroTypesCount)
        {
            int number = int.TryParse(input, out number) ? number : -1;

            if (IsValidStringInput(input) || number < 0 || number >= heroTypesCount)
                return true;

            return true;
        }
    }
}
