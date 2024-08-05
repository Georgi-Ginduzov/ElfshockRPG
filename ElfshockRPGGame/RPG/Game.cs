using RPG.Data.characters;
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
                        CharacterSelectScreen.Run(ref _hero);
                        _currentScreen = GameScreen.InGame;
                        break;
                    case GameScreen.InGame:
                        InGameScreen inGame = new(ref _hero);
                        inGame.Run();
                        break;
                    case GameScreen.Exit:
                        ExitScreen.Run();
                        break;
                }
            }
        }
    }
}
