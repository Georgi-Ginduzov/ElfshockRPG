using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.characters.heroes;
using Assert = NUnit.Framework.Assert;

namespace GameTests
{
    [TestClass]
    public class HeroTests
    {
        [Test]
        public void TestIncreaseStrength()
        {
            // Default strength is 2 => health = 5 * 2
            var hero = new Mage();
            hero.IncreaseStrength(2);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Strength, Is.EqualTo(4));
                Assert.That(hero.Health, Is.EqualTo(20));
            });
        }

        [Test]
        public void TestIncreaseAgility()
        {
            // Default agility is 3 => damage = 3 * 2
            var hero = new Warrior();
            hero.IncreaseAgility(2);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Agility, Is.EqualTo(5));
                Assert.That(hero.Damage, Is.EqualTo(10));
            });
        }

        [Test]
        public void TestIncreaseIntelligence()
        {
            // Default intelligence is 0 => mana = 0 * 3
            var hero = new Archer();
            hero.IncreaseIntelligence(2);

            Assert.Multiple(() =>
            {
                Assert.That(hero.Intelligence, Is.EqualTo(2));
                Assert.That(hero.Mana, Is.EqualTo(6));
            });
        }
    }
}
