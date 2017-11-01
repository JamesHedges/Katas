namespace BinaryChop
{
    public interface IBinaryChopStrategy<T>
    {
        T Locate(SortedArray<T> items, T searchTarget);
    }
}
