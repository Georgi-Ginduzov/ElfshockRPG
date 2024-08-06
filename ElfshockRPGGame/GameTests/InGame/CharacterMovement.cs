using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using RPG.screens;
using RPG.Data.characters;
using RPG.Data.characters.heroes;

using Assert = NUnit.Framework.Assert;

namespace GameTests.InGame
{
    [TestFixture]
    public class CharacterMovementTests
    {
        private Hero _hero;
        private Field _field;
        private InGameScreen _inGameScreen;

        [SetUp]
        public void Init()
        {
            _hero = new Warrior();
            
            _field = new Field(10, ',');
            _inGameScreen = new InGameScreen(ref _hero);
        }

        [Test]
        public void TestMoveUp()
        {
            _inGameScreen.MoveCharacter(_hero, -1, 0);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((0, 1)));
        }

        [Test]
        public void TestMoveLeft()
        {
            _inGameScreen.MoveCharacter(_hero, 0, -1);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((1, 0)));
        }

        [Test]
        public void TestMoveDown()
        {
            _inGameScreen.MoveCharacter(_hero, 1, 0);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((2, 1)));
        }

        [Test]
        public void TestMoveRight()
        {
            _inGameScreen.MoveCharacter(_hero, 0, 1);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((1, 2)));
        }

        [Test]
        public void TestMoveUpLeft()
        {
            _inGameScreen.MoveCharacter(_hero, -1, -1);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((0, 0)));
        }

        [Test]
        public void TestMoveUpRight()
        {
            _inGameScreen.MoveCharacter(_hero, -1, 1);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((0, 2)));
        }

        [Test]
        public void TestMoveDownLeft()
        {
            _inGameScreen.MoveCharacter(_hero, 1, -1);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((2, 0)));
        }

        [Test]
        public void TestMoveDownRight()
        {
            _inGameScreen.MoveCharacter(_hero, 1, 1);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((2, 2)));
        }

        [Test]
        public void TestMoveOutOfBounds()
        {   
            _inGameScreen.MoveCharacter(_hero, -2, 0);
            (int x, int y) = _hero.GetPosition();
            Assert.That((x, y), Is.EqualTo((1, 1))); 
        }

        [Test]
        public void TestMoveIntoOccupiedPosition()
        {
            (int monsterX, int monsterY) = (_inGameScreen.Monsters.FirstOrDefault()!).GetPosition();
            (int distanceX, int distanceY) = (monsterX - 1, monsterY - 1);
            
            _inGameScreen.MoveCharacter(_hero, distanceX, distanceY);

            (int x, int y) = _hero.GetPosition();

            Assert.That((x, y), Is.EqualTo((1, 1)));
        }
    }
}
