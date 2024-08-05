namespace RPG
{
    public class Field
    {
        private readonly char[,] _field;
        private readonly char _filler;


        public Field(int size, char filler)
        {
            Size = size;
            _filler = filler;
            _field = new char[size, size];

            Fill(_filler);
        }

        public int Size { get; }

        public char this[int x, int y]
        {
            get => _field[x, y];
            set => _field[x, y] = value;
        }

        private void Fill(char filler)
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    _field[x, y] = filler;
                }
            }
        }

        public bool IsOccupied(int x, int y)
        {   
            return _field[x, y] != _filler ;
        }

        public void UpdatePosition(int oldX, int oldY, int newX, int newY, char symbol)
        {
            _field[oldX, oldY] = _filler;
            _field[newX, newY] = symbol;
        }

        public void RemovePosition(int x, int y)
        {
            this[x, y] = _filler;
        }
    }
}
