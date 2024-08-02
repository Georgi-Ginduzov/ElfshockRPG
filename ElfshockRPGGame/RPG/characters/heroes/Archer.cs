namespace RPG.characters.heroes
{
    public class Archer : Hero
    {
        public Archer()
        {
            Strength = 2;
            Agility = 4;
            Intelligence = 0;
            Range = 2;
            Symbol = '#';

            Setup();
        }
    }
}