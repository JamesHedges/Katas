using Membership;
using System.Collections.Generic;

namespace Order.Tests
{
    public class SpyMembershipService : IMembershipService
    {
        private readonly List<string> _ProcessedItems;

        public SpyMembershipService()
        {
            _ProcessedItems = new List<string>();
        }

        public IEnumerable<string> ProcessedItems => _ProcessedItems;

        public void ActivateMembership(int customerId, string itemLine)
        {
            _ProcessedItems.Add(itemLine);
        }
    }
}
