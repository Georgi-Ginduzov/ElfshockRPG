using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.Data.characters.heroes;
using RPG.Data.characters;
using RPG.screens;
using Moq;

namespace GameTests.InGame
{
    [TestClass]
    public class HealthManaDisplayTests
    {
        private Hero _hero;
        private InGameScreen _inGameScreen;
        private Mock<TextWriter> _mockTextWriter;

        [SetUp]
        public void Init()
        {
            _hero = new Warrior();
            _inGameScreen = new InGameScreen();
            _mockTextWriter = new Mock<TextWriter>();
            Console.SetOut(_mockTextWriter.Object);
        }

        [Test]
        public void TestHealthManaDisplay()
        {
            _inGameScreen.Render();

            _mockTextWriter.Verify(tw => tw.WriteLine(It.Is<string>(s => s.Contains("Health: 25    Mana: 0"))), Times.Once);            
        }
    }
}
