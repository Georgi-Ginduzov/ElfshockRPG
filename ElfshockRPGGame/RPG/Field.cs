namespace RPG
{
    public class Field(int size)
    {
        private const char filler = ',';

        public int Size { get; } = size;
    }
}
