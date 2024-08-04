namespace RPG
{
    public class Field(int size)
    {
        private readonly char[,] _field = new char[size, size];

        public int Size { get; } = size;

        public char this[int x, int y]
        {
            get => _field[x, y];
            set => _field[x, y] = value;
        }
    }
}
