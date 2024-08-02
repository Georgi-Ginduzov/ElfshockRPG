using RPG.characters.contracts;

namespace RPG.characters
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
    }
}
