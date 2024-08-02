using RPG.characters.contracts;

namespace RPG.characters
{
    public abstract class Hero : Character, IBuff
    {
        protected Hero()
        {
            _x = 1;
            _y = 1;
        }
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
