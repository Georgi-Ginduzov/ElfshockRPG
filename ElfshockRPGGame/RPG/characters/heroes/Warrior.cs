namespace RPG.characters.heroes
{
    public class Warrior : Hero
    {
        public Warrior()
        {
            Strength = 3;
            Agility = 3;
            Intelligence = 0;
            Range = 1;
            Symbol = '@';

            Setup();
        }
    }
}
