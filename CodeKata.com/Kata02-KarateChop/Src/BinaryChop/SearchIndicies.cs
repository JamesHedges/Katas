namespace BinaryChop
{
    public class SearchIndicies
    {
        public SearchIndicies(int high, int low)
        {
            High = high;
            Low = low;
        }

        public int High { get; }
        public int Low { get; }
        public int Mid => (High + Low) / 2;
    }
}
