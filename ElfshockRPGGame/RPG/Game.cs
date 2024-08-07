using RPG.screens;

namespace RPG
{
    public class Game
    {
        private GameScreen _currentScreen = GameScreen.MainMenu;
       
        public async Task RunAsync()
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
                        CharacterSelectScreen selectionScreen = new();
                        await selectionScreen.RunAsync();
                        _currentScreen = GameScreen.InGame;
                        break;
                    case GameScreen.InGame:
                        InGameScreen inGame = new();
                        inGame.Run();
                        break;
                    case GameScreen.Exit:
                        ExitScreen.Run();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
