using System;

namespace BinaryChop
{
    public interface IBinaryChopStrategy<T>
    {
        T Locate(SortedArray<T> items, T searchTarget);
    }

    public class HalvingSearchStrategy : IBinaryChopStrategy<int>
    {
        public int Locate(SortedArray<int> items, int searchTarget)
        {
            int found = -1;
            int testIndex;
            int topIndex = items.Length -1;
            int bottomIndex = 0;
            testIndex = (topIndex - bottomIndex) / 2;

            while (found == -1 && testIndex >= bottomIndex && testIndex <= topIndex )
            {
                if (items[testIndex] == searchTarget)
                {
                    found = testIndex;
                }
                else if (searchTarget < items[testIndex])
                {
                    topIndex = testIndex -1;
                    //testIndex = (topIndex - bottomIndex) / 2;
                    testIndex = (topIndex + bottomIndex) / 2;
                }
                else
                {
                    bottomIndex = testIndex + 1;
                    //testIndex += 1 + (topIndex - bottomIndex) / 2;
                    testIndex = (topIndex + bottomIndex) / 2;
                }
            }

            return found;
        }
    }
}
