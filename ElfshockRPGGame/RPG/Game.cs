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

        

        private void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("Exiting the game. Goodbye!");
            Environment.Exit(0);
        }

        
    }

}
