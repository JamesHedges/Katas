using System;

namespace BinaryChop
{

    public abstract class BinaryChopStrategy<T> : IBinaryChopStrategy<T>
    {
        protected const int NotFound = -1;
        public abstract T Locate(SortedArray<T> items, T searchTarget);

        protected static SearchIndicies NextIndices(int compareItem, int searchTarget, SearchIndicies searchIndicies)
        {
            return searchTarget < compareItem ?
                new SearchIndicies(searchIndicies.Mid - 1, searchIndicies.Low) :
                new SearchIndicies(searchIndicies.High, searchIndicies.Mid + 1);
        }
    }
}
