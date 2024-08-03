using RPG.characters;

namespace RPG
{
    public class InGame
    {
        private HashSet<Character> _characters;
        
        public InGame(Hero hero, Monster monster)
        {
            _characters = new HashSet<Character>([hero, monster]);
        }

        public IReadOnlyCollection<Character> Characters { get => _characters; }

        private void AddMonster()
        {
            _characters.Add(new Monster());
        }
        
    }
}
