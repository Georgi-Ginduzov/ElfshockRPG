namespace RPG.characters.contracts
{
    public interface IBuff
    {
        public void IncreaseStrength(int points);
        public void IncreaseAgility(int points);
        public void IncreaseIntelligence(int points);
    }
}
