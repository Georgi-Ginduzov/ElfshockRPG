using RPG.characters.heroes;
using RPG.characters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GameTests.characterSelectScreenTests
{
    [TestClass]
    public class GameTests
    {
        // Character creation tests
        [Test]
        public void TestHeroCreation_Mage()
        {
            var hero = CreateHero<Mage>();

            Assert.Multiple(() =>
            {
                Assert.That(hero, Is.Not.Null);
                Assert.That(hero, Is.InstanceOf<Mage>());
                Assert.That(hero.Strength, Is.EqualTo(2));
                Assert.That(hero.Agility, Is.EqualTo(1));
                Assert.That(hero.Intelligence, Is.EqualTo(3));
                Assert.That(hero.Range, Is.EqualTo(3));
                Assert.That(hero.Symbol, Is.EqualTo('*'));

                Assert.That(hero.Health, Is.EqualTo(10));
                Assert.That(hero.Mana, Is.EqualTo(9));
                Assert.That(hero.Damage, Is.EqualTo(2));
            });
        }

        [Test]
        public void TestHeroCreation_Warrior()
        {
            var hero = CreateHero<Warrior>();

            Assert.Multiple(() =>
            {
                Assert.That(hero, Is.Not.Null);
                Assert.That(hero, Is.InstanceOf<Warrior>());
                Assert.That(hero.Strength, Is.EqualTo(3));
                Assert.That(hero.Agility, Is.EqualTo(3));
                Assert.That(hero.Intelligence, Is.EqualTo(0));
                Assert.That(hero.Range, Is.EqualTo(1));
                Assert.That(hero.Symbol, Is.EqualTo('@'));

                Assert.That(hero.Health, Is.EqualTo(15));
                Assert.That(hero.Mana, Is.EqualTo(0));
                Assert.That(hero.Damage, Is.EqualTo(6));
            });
        }

        [Test]
        public void TestHeroCreation_Archer()
        {
            var hero = CreateHero<Archer>();

            Assert.Multiple(() =>
            {
                Assert.That(hero, Is.Not.Null);
                Assert.That(hero, Is.InstanceOf<Archer>());
                Assert.That(hero.Strength, Is.EqualTo(2));
                Assert.That(hero.Agility, Is.EqualTo(4));
                Assert.That(hero.Intelligence, Is.EqualTo(0));
                Assert.That(hero.Range, Is.EqualTo(2));
                Assert.That(hero.Symbol, Is.EqualTo('#'));

                Assert.That(hero.Health, Is.EqualTo(10));
                Assert.That(hero.Mana, Is.EqualTo(0));
                Assert.That(hero.Damage, Is.EqualTo(8));
            });
        }

        [Test]
        public void TestMonsterCreation()
        {
            Monster monster = new();

            Assert.Multiple(() =>
            {
                Assert.That(monster, Is.Not.Null);
                Assert.That(monster.Strength, Is.InRange(1, 3));
                Assert.That(monster.Agility, Is.InRange(1, 3));
                Assert.That(monster.Intelligence, Is.InRange(1, 3));
                Assert.That(monster.Range, Is.EqualTo(1));
                Assert.That(monster.Symbol, Is.EqualTo('◙'));
            });
        }

        private T CreateHero<T>() where T : Hero
        {
            var heroType = typeof(T);
            var hero = Activator.CreateInstance(heroType) as Hero;

            if (hero == null)
            {
                throw new InvalidOperationException($"Failed to create an instance of {heroType.Name}");
            }

            return (hero as T)!;
        }


        // Character points distribution tests
        [Test]
        public void TestDistributePoints_Mage()
        {
            var hero = new Mage();
            DistributePoints(hero, 1, 1, 1);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Strength, Is.EqualTo(3));
                Assert.That(hero.Agility, Is.EqualTo(2));
                Assert.That(hero.Intelligence, Is.EqualTo(4));
                Assert.That(hero.Health, Is.EqualTo(15));
                Assert.That(hero.Mana, Is.EqualTo(12));
                Assert.That(hero.Damage, Is.EqualTo(4));
            });
        }

        [Test]
        public void TestDistributePoints_Warrior()
        {
            var hero = new Warrior();
            DistributePoints(hero, 2, 1, 0);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Strength, Is.EqualTo(5));
                Assert.That(hero.Agility, Is.EqualTo(4));
                Assert.That(hero.Intelligence, Is.EqualTo(0));
                Assert.That(hero.Health, Is.EqualTo(25));
                Assert.That(hero.Mana, Is.EqualTo(0));
                Assert.That(hero.Damage, Is.EqualTo(8));
            });
        }

        [Test]
        public void TestDistributePoints_Archer()
        {
            var hero = new Archer();
            DistributePoints(hero, 0, 3, 0);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Strength, Is.EqualTo(2));
                Assert.That(hero.Agility, Is.EqualTo(7));
                Assert.That(hero.Intelligence, Is.EqualTo(0));
                Assert.That(hero.Health, Is.EqualTo(10));
                Assert.That(hero.Mana, Is.EqualTo(0));
                Assert.That(hero.Damage, Is.EqualTo(14));
            });
        }

        private void DistributePoints(Hero hero, int strengthPoints, int agilityPoints, int intelligencePoints)
        {
            hero.IncreaseStrength(strengthPoints);
            hero.IncreaseAgility(agilityPoints);
            hero.IncreaseIntelligence(intelligencePoints);
        }




    }
}