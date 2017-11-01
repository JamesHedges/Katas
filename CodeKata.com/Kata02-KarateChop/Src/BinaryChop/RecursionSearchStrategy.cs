namespace BinaryChop
{
    public class RecursionSearchStrategy : BinaryChopStrategy<int>
    {
        public override int Locate(SortedArray<int> items, int searchTarget)
        {
           SearchIndicies searchIndicies = new SearchIndicies(items.Length - 1, 0);
           return FindTarget(items, searchTarget, searchIndicies);
        }

        private int FindTarget(SortedArray<int> items, int searchTarget, SearchIndicies searchIndicies)
        {

            if (items.Length == 0 || 
                searchIndicies.Mid < searchIndicies.Low || 
                searchIndicies.Mid > searchIndicies.High)
            {
                return NotFound;
            }
            else if (items[searchIndicies.Mid] == searchTarget)
            {
                return searchIndicies.Mid;
            }
            else
            {
                SearchIndicies nextInidicies = NextIndices(items[searchIndicies.Mid], searchTarget, searchIndicies);
                return FindTarget(items, searchTarget, nextInidicies);
            }
        }
    }
}
