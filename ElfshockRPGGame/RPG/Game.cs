using RPG.characters;
using RPG.screens;

namespace RPG
{
    public class Game
    {
        private GameScreen _currentScreen = GameScreen.MainMenu;
        private const int maxPointsForDistribution = 3;
       
        private Hero _hero;
        

        public void Run()
        {
            while (_currentScreen != GameScreen.Exit)
            {
                switch (_currentScreen)
                {
                    case GameScreen.MainMenu:
                        MainMenu.Run();
                        _currentScreen = GameScreen.CharacterSelect;
                        break;
                    case GameScreen.CharacterSelect:
                        CharacterSelectScreen.Run();
                        _currentScreen = GameScreen.InGame;
                        break;
                    case GameScreen.InGame:
                        ShowInGame();
                        break;
                    case GameScreen.Exit:
                        ExitScreen.Run();
                        break;
                }
            }
        }

        private void ShowInGame()
        {
            // In-game logic here
            Console.Clear();
            Console.WriteLine("In Game Screen");
            Console.WriteLine("Press 'E' to exit to Main Menu.");
            if (Console.ReadKey().Key == ConsoleKey.E)
            {
                _currentScreen = GameScreen.Exit;
            }
        }


        private void PrintField()
        {

        }
        
    }

}
