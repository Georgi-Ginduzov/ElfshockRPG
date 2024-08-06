using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.Data.characters;
using RPG.screens;
using RPG.Data.characters.heroes;

using Assert = NUnit.Framework.Assert;

namespace GameTests.InGame
{

    [TestClass]
    public class CombatMechanicsTests
    {
        private Hero _hero;
        private Monster _monster;
        private InGameScreen _inGameScreen;

        [SetUp]
        public void Init()
        {
            _hero = new Mage();
            _monster = new Monster();
            _inGameScreen = new InGameScreen(ref _hero);
        }

        [Test]
        public void TestAttack()
        {
            int initialMonsterHealth = _monster.Health;

            _hero.Attack(_monster);

            Assert.That(_monster.Health, Is.EqualTo(initialMonsterHealth - _hero.Damage));
        }

        [Test]
        public void TestDeadCharacterRemovalAfterAttack()
        {
            Character monster = _inGameScreen.Monsters.FirstOrDefault()!;

            while (monster.Health > 0)
            {
                _hero.Attack(monster);
            }

            (int deadCharacterX, int deadCharacterY) = monster.GetPosition();
            _inGameScreen.HandleDeadCharacter(monster);
            char fieldSymbol = _inGameScreen.Field[deadCharacterX, deadCharacterY];

            Assert.That(fieldSymbol, Is.Not.EqualTo(monster.Symbol));
            Assert.That(fieldSymbol, Is.EqualTo(_inGameScreen.Field[0, 0])); // equals to an empty space
        }

        [Test]
        public void TestNearMonstersDisplay()
        {
            _inGameScreen.GenerateMonster();

            int x = 0;
            int y = 0;

            foreach (var monster in _inGameScreen.Monsters)
            {
                monster.SetPosition(x, y);
                x += 2;
                y += 2;
            }

            int expected = 2;
            int actual = _inGameScreen.NearEnemies().Count();

            Assert.That(actual, Is.EqualTo(expected));

            _inGameScreen.GenerateMonster();
            Monster lastMonster = _inGameScreen.Monsters.Last();
            lastMonster.SetPosition(x + 2, y + 2);

            actual = _inGameScreen.NearEnemies().Count();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestGenerateMonster()
        {
            int initialMonsterCount = _inGameScreen.Monsters.Count;

            _inGameScreen.GenerateMonster();

            Assert.That(_inGameScreen.Monsters, Has.Count.EqualTo(initialMonsterCount + 1));

            Monster newMonster = _inGameScreen.Monsters.Last();
            (int x, int y) = newMonster.GetPosition();

            _inGameScreen.SetupGameField();

            Assert.That(_inGameScreen.Field.IsOccupied(x, y), Is.True);
        }

        [Test]
        public void TestIsInRange()
        {
            // Test cases where the target is within range
            Assert.That(_inGameScreen.IsInRange(0, 0, 3), Is.True);
            Assert.That(_inGameScreen.IsInRange(1, 1, 3), Is.True);
            Assert.That(_inGameScreen.IsInRange(2, 2, 3), Is.True);
            Assert.That(_inGameScreen.IsInRange(3, 0, 3), Is.True);
            Assert.That(_inGameScreen.IsInRange(0, 3, 3), Is.True);

            // Test cases where the target is out of range
            Assert.That(_inGameScreen.IsInRange(4, 0, 3), Is.False);
            Assert.That(_inGameScreen.IsInRange(0, 4, 3), Is.False);
            Assert.That(_inGameScreen.IsInRange(4, 4, 3), Is.False);
        }
    }
}
