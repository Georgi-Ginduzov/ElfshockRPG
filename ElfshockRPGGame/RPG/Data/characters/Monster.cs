namespace RPG.Data.characters
{
    public class Monster : Character
    {
        private const int randomMinStat = 1;
        private const int randomMaxStat = 3;
        private readonly Random _random = new();

        public Monster()
        {
            Strength = _random.Next(randomMinStat, randomMaxStat);
            Agility = _random.Next(randomMinStat, randomMaxStat);
            Intelligence = _random.Next(randomMinStat, randomMaxStat);
            Range = 1;
            Symbol = '◙';

            Setup();
        }

        public void LocationSetup(int min, int max)
        {
            _x = _random.Next(min, max);
            _y = _random.Next(min, max);
        }

        public (int x, int y) CalculateNextMove(Hero hero)
        {
            var (heroX, heroY) = hero.GetPosition();
            var distanceX = heroX - _x;
            var distanceY = heroY - _y;

            var moveX = distanceX != 0 ? distanceX / Math.Abs(distanceX) : 0;
            var moveY = distanceY != 0 ? distanceY / Math.Abs(distanceY) : 0;

            return (moveX, moveY);
        }
    }
}
