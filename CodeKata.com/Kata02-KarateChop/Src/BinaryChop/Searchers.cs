using System;

namespace BinaryChop
{
    public static class Searchers
    {
        public static int Search(this SortedArray<int> sortedArray, int searchNumber, IBinaryChopStrategy<int> searchStrategy)
        {
            return searchStrategy.Locate(sortedArray, searchNumber);
        }
    }
}
