using RPG.characters;
using System.Reflection;

namespace RPG
{
    public class Game
    {
        private GameScreen _currentScreen = GameScreen.MainMenu;
        private const int maxPointsForDistribution = 3;

        public void Run()
        {
            while (_currentScreen != GameScreen.Exit)
            {
                switch (_currentScreen)
                {
                    case GameScreen.MainMenu:
                        ShowMainMenu();
                        break;
                    case GameScreen.CharacterSelect:
                        ShowCharacterSelect();
                        break;
                    case GameScreen.InGame:
                        ShowInGame();
                        break;
                    case GameScreen.Exit:
                        ExitGame();
                        break;
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome!");
            Console.WriteLine("Press any key to play.");
            Console.ReadKey();
            _currentScreen = GameScreen.CharacterSelect;
        }

        private void ShowCharacterSelect()
        {
            Console.Clear();
            Console.WriteLine("Choose character type:");

            var heroTypes = GetHeroTypes();
            for (int i = 0; i < heroTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {heroTypes[i].Name}");
            }
                        
            string? choice = Console.ReadLine();
            while(!IsValidHeroTypeNumber(choice, heroTypes.Length))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                choice = Console.ReadLine();
            }

            int selectedIndex = int.Parse(choice) - 1;
            Type selectedHeroType = heroTypes[selectedIndex];
            Hero hero = Activator.CreateInstance(type: selectedHeroType) as Hero;

            Console.WriteLine($"Would you like to buff up your stats before starting?        (Limit: {maxPointsForDistribution} points total");
            Console.WriteLine("Response (Y/N): ");
            choice = Console.ReadLine();
            while (!IsValidStringInput(choice) || choice != "y" || choice != "n")
            {   
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                choice = Console.ReadLine();
            }
            
            if (choice.Equals("y"))
            {
                DistributePoints(hero);
            }

            SaveHeroToDatabase(hero);
            Console.WriteLine($"Hero {hero.GetType().Name} created and saved to database.");
            _currentScreen = GameScreen.InGame;
        }

       

        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Exiting the game. Goodbye!");
            Environment.Exit(0);
        }

        private void DistributePoints(Hero hero)
        {
            int pointsInput;
            int remainingPoints = maxPointsForDistribution;

            Console.WriteLine("Remaining points: " + maxPointsForDistribution);
            
            Console.WriteLine("Add to Strength: ");
            pointsInput = int.Parse(Console.ReadLine());

            while (!IsValidPointsInput(pointsInput, remainingPoints))
            {
                pointsInput = int.Parse(Console.ReadLine());
            }

            if (pointsInput > 0)
            {
                hero.Strength += pointsInput;
                remainingPoints -= pointsInput;

                if (remainingPoints == 0)
                {
                    return;
                }
            }


            Console.WriteLine("Add to Agility: ");
            pointsInput = int.Parse(Console.ReadLine());

            while (!IsValidPointsInput(pointsInput, remainingPoints))
            {
                pointsInput = int.Parse(Console.ReadLine());
            }

            if (pointsInput > 0)
            {
                hero.Agility += pointsInput;
                remainingPoints -= pointsInput;

                if (remainingPoints == 0)
                {
                    return;
                }
            }


            Console.WriteLine("Add to Intelligence: ");
            pointsInput = int.Parse(Console.ReadLine());

            while (!IsValidPointsInput(pointsInput, remainingPoints))
            {
                pointsInput = int.Parse(Console.ReadLine());
            }

            if (pointsInput > 0)
            {
                hero.Agility += pointsInput;
                remainingPoints -= pointsInput;                
            }
        }

        


        private static bool IsValidPointsInput(int input, int remainingPoints) => input >= 0 && input <= remainingPoints;
        private static bool IsValidStringInput(string? input) => !string.IsNullOrEmpty(input) && input != " ";
        private static bool IsValidHeroTypeNumber(string? input, int heroTypesCount)
        {
            int number = int.TryParse(input, out number) ? number : -1;

            if (IsValidStringInput(input) || number < 0 || number >= heroTypesCount)
                return false;
            
            return true;
        }

        private Type[] GetHeroTypes() => Assembly.GetAssembly(typeof(Hero))
                           .GetTypes()
                           .Where(t => t.IsSubclassOf(typeof(Hero)) && !t.IsAbstract)
                           .ToArray();
    }

}
