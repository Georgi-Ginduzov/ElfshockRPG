namespace RPG.Data.characters.contracts
{
    public interface ICharacter
    {
        public void Move(int dx, int dy);
        public void Attack(Character character);
    }
}
