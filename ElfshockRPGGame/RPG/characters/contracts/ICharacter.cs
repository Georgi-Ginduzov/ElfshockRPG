namespace RPG.characters.contracts
{
    public interface ICharacter
    {
        public void Move(int dx, int dy);
        public void Attack();
    }
}
