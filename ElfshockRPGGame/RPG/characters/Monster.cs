namespace RPG.characters
{
    public class Monster : Character
    {
        private const int randomMin = 1;
        private const int randomMax = 3;
        private readonly Random _random = new Random();

        public Monster()
        {
        
            Strength = _random.Next(randomMin, randomMax);
            Agility = _random.Next(randomMin, randomMax);
            Intelligence = _random.Next(randomMin, randomMax);
            Range = 1;
            Symbol = '◙';
            
            Setup();
        }
    }
}
