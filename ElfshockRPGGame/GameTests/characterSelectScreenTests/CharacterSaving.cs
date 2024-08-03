using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using RPG.characters.heroes;
using RPG.models;
using Assert = NUnit.Framework.Assert;

namespace GameTests.characterSelectScreenTests
{
    [TestClass]
    public class CharacterSaving
    {
        private DbContextOptions<GameContext> GetInMemoryOptions() => new DbContextOptionsBuilder<GameContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        [Test]
        public void HeroIsSavedCorrectlyWithoutBeingBuffed()
        {
            var options = GetInMemoryOptions();

            using (var context = new GameContext(options))
            {
                var hero = new Warrior();
                var heroEntity = new HeroEntity
                {
                    Id = hero.Id,
                    Type = nameof(Warrior),
                    Strength = hero.Strength,
                    Agility = hero.Agility,
                    Intelligence = hero.Intelligence,
                    Range = hero.Range,
                    Symbol = hero.Symbol,
                    Health = hero.Health,
                    Mana = hero.Mana,
                    Damage = hero.Damage,
                    CreationTime = hero.CreationTime
                };

                context.Heroes.Add(heroEntity);
                context.SaveChanges();

                var savedHero = context.Heroes.FirstOrDefault(h => h.Id == hero.Id);
                
                Assert.That(savedHero, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(savedHero.Id, Is.EqualTo(hero.Id));
                    Assert.That(savedHero.Strength, Is.EqualTo(hero.Strength));
                    Assert.That(savedHero.Agility, Is.EqualTo(hero.Agility));
                    Assert.That(savedHero.Intelligence, Is.EqualTo(hero.Intelligence));
                    Assert.That(savedHero.Range, Is.EqualTo(hero.Range));
                    Assert.That(savedHero.Symbol, Is.EqualTo(hero.Symbol));
                    Assert.That(savedHero.CreationTime, Is.EqualTo(hero.CreationTime));
                });
            }
        }        
    }
}
