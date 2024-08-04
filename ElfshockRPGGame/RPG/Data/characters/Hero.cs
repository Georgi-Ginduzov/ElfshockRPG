using RPG.Data.characters.contracts;

namespace RPG.Data.characters
{
    public abstract class Hero : Character, IBuff, ISaveableHero
    {
        protected Hero()
        {
            _x = 1;
            _y = 1;

            CreationTime = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public DateTime CreationTime { get; }
        public Guid Id { get; }

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
            // while in bounds and not dead
            var key = Console.ReadKey().Key;
            var movementMap = new Dictionary<ConsoleKey, (int dx, int dy)>
            {
                { ConsoleKey.W, (0, -1) }, // Up
                { ConsoleKey.S, (0, 1) },  // Down
                { ConsoleKey.A, (-1, 0) }, // Left
                { ConsoleKey.D, (1, 0) },  // Right
                { ConsoleKey.Q, (-1, -1) }, // Up-Left
                { ConsoleKey.E, (1, -1) },  // Up-Right
                { ConsoleKey.Z, (-1, 1) },  // Down-Left
                { ConsoleKey.X, (1, 1) }    // Down-Right
            };

            if (movementMap.TryGetValue(key, out var movement))
            {
                Move(movement.dx, movement.dy);
            }
        }
    }
}
