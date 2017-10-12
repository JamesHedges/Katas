using Shipping;
using System.Collections.Generic;

namespace Order.Tests
{
    public class SpyShippingService : IShippingService
    {
        private readonly List<string> _ProcessedItems;

        public SpyShippingService()
        {
            _ProcessedItems = new List<string>();
        }

        public IEnumerable<string> ProcessedItems => _ProcessedItems;

        public void GenerateShippingLabel(int customerId, string itemLine)
        {
            _ProcessedItems.Add(itemLine);
        }
    }
}
