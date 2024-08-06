using Microsoft.IdentityModel.Tokens;
using RPG.Data.characters;
using System.Text;

namespace RPG.screens
{
    public class InGameScreen
    {
        private const int _fieldSize = 10;
        private const char _fieldFiller = ',';

        private readonly Hero _hero;
        private readonly HashSet<Monster> _monsters;
        private readonly Field _field;

        public InGameScreen(ref Hero hero)
        {
            _hero = hero;
            _field = new Field(_fieldSize, _fieldFiller);

            _monsters = [];
            GenerateMonster();

            SetupGameField();
        }

        public IReadOnlyCollection<Monster> Monsters { get => _monsters; }

        public void Run()
        {

            while (true)
            {
                Render();

                char? input = default;

                while (true)
                {
                    switch (input)
                    {
                        case (char)ConsoleKey.D1:
                            HeroAttack();
                            break;
                        case (char)ConsoleKey.D2:
                            HandleInput();
                            break;
                        default:
                            input = char.Parse(Console.ReadLine());
                            continue;
                    }

                    MonstersTurn();
                    break;
                }
            }
        }
         
        private void HeroAttack()
        {
            int i = 0;

            List<Monster> nearEnemies = CheckForNearEnemies().ToList();

            if (nearEnemies.IsNullOrEmpty())
            {
                Console.WriteLine("No available targets in your range");
                return;
            }

            foreach (Character monster in nearEnemies)
            {
                Console.WriteLine($"{i++}) target with remaining blood {monster.Health}");
            }

            Console.Write("Which one to attack: ");

            int numberOfMonsterToAttck = int.Parse(Console.ReadLine());

            while (numberOfMonsterToAttck >= _monsters.Count || numberOfMonsterToAttck < 0)
            {
                Console.Write("Invalid monster number. Please try again: ");
                numberOfMonsterToAttck = int.Parse(Console.ReadLine());
            }

            Monster monsterToAttack = _monsters.ElementAtOrDefault(numberOfMonsterToAttck);

            _hero.Attack(monsterToAttack);

            if (monsterToAttack.Health <= 0)
            {
                _monsters.Remove(monsterToAttack);
                RemoveFromField(monsterToAttack);
            }
        }

        private void RemoveFromField(Character character)
        {
            (int x, int y) = character.GetPosition();
            _field.RemovePosition(x, y);
        }

        private IEnumerable<Monster> CheckForNearEnemies()
        {
            (int x, int y) = _hero.GetPosition();
            List<Monster> nearMonsters = new();

            foreach (var monster in _monsters)
            {
                (int monsterX, int monsterY) = monster.GetPosition();

                if (IsInRange(x - monsterX, y - monsterY, _hero.Range))
                {
                    nearMonsters.Add(monster);
                }
            }

            return nearMonsters;
        }

        private bool IsInRange(int distanceX, int distanceY, int range) 
            => Math.Abs(distanceX) <= range && Math.Abs(distanceY) <= range;

        public void Render()
        {
            Console.Clear();

            Console.WriteLine($"Health: {_hero.Health}    Mana: {_hero.Mana}");
            Console.WriteLine();

            Console.OutputEncoding = Encoding.UTF8;
            
            SetupGameField();
            PrintGameField();

            Console.OutputEncoding = Encoding.Default;

            Console.WriteLine("Choose an action");
            Console.WriteLine("1) Attack");
            Console.WriteLine("2) Move");
        }

        private void SetupGameField()
        {
            foreach (var monster in _monsters)
            {
                _field[monster.GetPosition().x, monster.GetPosition().y] = monster.Symbol;
            }

            var (heroX, heroY) = _hero.GetPosition();
            _field[heroX, heroY] = _hero.Symbol;
        }

        private void PrintGameField()
        {
            for (int x = 0; x < _field.Size; x++)
            {
                for (int y = 0; y < _field.Size; y++)
                {
                    Console.Write(_field[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void GenerateMonster()
        {
            Monster monster = new();
            monster.LocationSetup(0, _fieldSize);
            
            while (monster.GetPosition == _hero.GetPosition)
            {
                monster.LocationSetup(0, _fieldSize);
            }

            _monsters.Add(monster);
        }

        private void HandleInput()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    MoveCharacter(_hero, -1, 0);
                    break;
                case ConsoleKey.A:
                    MoveCharacter(_hero, 0, -1);
                    break;
                case ConsoleKey.S:
                    MoveCharacter(_hero, 1, 0);
                    break;
                case ConsoleKey.D:
                    MoveCharacter(_hero, 0, 1);
                    break;
                case ConsoleKey.Q:
                    MoveCharacter(_hero, -1, -1);
                    break;
                case ConsoleKey.Z:
                    MoveCharacter(_hero, 1, -1);
                    break;
                case ConsoleKey.E:
                    MoveCharacter(_hero, -1, 1);
                    break;
                case ConsoleKey.X:
                    MoveCharacter(_hero, 1, 1);
                    break;
            }
        }

        public void MoveCharacter(Character character, int dx, int dy)
        {
            var (oldX, oldY) = character.GetPosition();
            var newX = oldX + dx;
            var newY = oldY + dy;

            if (newX < 0 || newX >= _field.Size || newY < 0 || newY >= _field.Size)
            {
                return;
            }

            if (_field.IsOccupied(newX, newY))
            {
                return;
            }

            character.Move(dx, dy);
            _field.UpdatePosition(oldX, oldY, newX, newY, character.Symbol);
        }

        public void MonstersTurn()
        {
            (int heroX, int heroY) = _hero.GetPosition();
            foreach (var monster in _monsters)
            {
                (int oldX, int oldY) = monster.GetPosition();
                (int distanceX, int distanceY) = (heroX - oldX, heroY - oldY);

                if (IsInRange(distanceX, distanceY, monster.Range))
                {
                    monster.Attack(_hero);
                    continue;
                }

                (int xMove, int yMove) = monster.CalculateNextMove(_hero);
                (int newX, int newY) = (oldX + xMove, oldY + yMove);

                monster.Move(xMove, yMove);

                _field.UpdatePosition(oldX, oldY, newX, newY, monster.Symbol);
            }

            Render();

            GenerateMonster();

            Render();
        }


    }
}
