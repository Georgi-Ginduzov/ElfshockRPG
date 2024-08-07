using RPG.Data.characters.contracts;
using RPG.Data.models;
using System.Reflection;

namespace RPG.Data.characters
{
    public abstract class Hero : Character, IBuff, ISaveableHero
    {
        private Guid _id;
        private DateTime _creationTime;

        protected Hero()
        {
            _x = 1;
            _y = 1;

            _creationTime = DateTime.Now;
            _id = Guid.NewGuid();
        }

        public DateTime CreationTime { get => _creationTime; }
        public Guid Id { get => _id; }

        public void IncreaseStrength(int points)
        {
            Strength += points;
            Setup();
        }

        public void IncreaseAgility(int points)
        {
            Agility += points;
            Setup();
        }

        public void IncreaseIntelligence(int points)
        {
            Intelligence += points;
            Setup();
        }

        public void Move()
        {
            var key = Console.ReadKey().Key;
            var movementMap = new Dictionary<ConsoleKey, (int dx, int dy)>
                {
                    { ConsoleKey.W, (0, -1) },
                    { ConsoleKey.S, (0, 1) },
                    { ConsoleKey.A, (-1, 0) },
                    { ConsoleKey.D, (1, 0) },
                    { ConsoleKey.Q, (-1, -1) },
                    { ConsoleKey.E, (1, -1) },
                    { ConsoleKey.Z, (-1, 1) },
                    { ConsoleKey.X, (1, 1) }
                };

            if (movementMap.TryGetValue(key, out var movement))
            {
                Move(movement.dx, movement.dy);
            }
        }

        public static explicit operator Hero(HeroEntity entity)
        {
            Type? heroType = (Assembly.GetAssembly(typeof(Hero)))?
                .GetTypes()
                .FirstOrDefault(t => t.Name == entity.Type);

            if (heroType == null)
            {
                throw new InvalidOperationException($"Hero type '{entity.Type}' not found.");
            }

            var hero = (Hero)Activator.CreateInstance(heroType)!;
            hero._id = entity.Id;
            hero.Strength = entity.Strength;
            hero.Agility = entity.Agility;
            hero.Intelligence = entity.Intelligence;
            hero.Range = entity.Range;
            hero.Symbol = entity.Symbol;
            hero.Health = entity.Health;
            hero.Mana = entity.Mana;
            hero.Damage = entity.Damage;
            hero._creationTime = entity.CreationTime;

            return hero;
        }
    }
}
