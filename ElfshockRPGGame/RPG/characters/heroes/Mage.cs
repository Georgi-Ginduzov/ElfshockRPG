namespace RPG.characters.heroes
{
    public class Mage : Hero
    {
        public Mage() : base()
        {
            Strength = 2;
            Agility = 1;
            Intelligence = 3;
            Range = 3;
            Symbol = '*';

            Setup();
        }


    }
}
