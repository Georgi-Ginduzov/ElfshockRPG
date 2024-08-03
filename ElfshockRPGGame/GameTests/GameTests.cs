using RPG.characters.heroes;
using RPG.characters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace GameTests
{
    [TestClass]
    public class GameTests
    {
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
    }
}