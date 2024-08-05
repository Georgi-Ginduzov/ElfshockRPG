namespace RPG.Data.characters.contracts
{
    public interface ISaveableHero : ISaveable
    {
        public DateTime CreationTime { get; }
    }
}
