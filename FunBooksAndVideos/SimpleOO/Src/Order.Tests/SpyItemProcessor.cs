using System.Collections.Generic;
using Order.Processor;

namespace Order.Tests
{
    public class SpyItemProcessor : IItemProcessor
    {
        private readonly List<IItemLine> _ItemsProcessed;

        public SpyItemProcessor(List<IItemLine> itemsProcessed)
        {
            _ItemsProcessed = itemsProcessed;
        }

        public void HandlePurchaseOrderItem(int customerId, IItemLine item)
        {
            _ItemsProcessed.Add(item);
        }
    }
}
