namespace BinaryChop
{
    public class WhileLoopSearchStrategy : BinaryChopStrategy<int>
    {
        public override int Locate(SortedArray<int> items, int searchTarget)
        {
            int found = NotFound;
            SearchIndicies searchIndicies = new SearchIndicies(items.Length - 1, 0);

            while (found == -1 && searchIndicies.Mid >= searchIndicies.Low && searchIndicies.Mid <= searchIndicies.High )
            {
                if (items[searchIndicies.Mid] == searchTarget)
                {
                    found = searchIndicies.Mid;
                }
                else
                {
                    searchIndicies = NextIndices(items[searchIndicies.Mid], searchTarget, searchIndicies);
                }
            }

            return found;
        }

        //private static SearchIndicies NextIndices(int compareItem, int searchTarget, SearchIndicies searchIndicies)
        //{
        //    return searchTarget < compareItem ? 
        //        new SearchIndicies(searchIndicies.Mid - 1, searchIndicies.Low) : 
        //        new SearchIndicies(searchIndicies.High, searchIndicies.Mid + 1);
        //}
    }
}
