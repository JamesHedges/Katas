using System.Linq;
using System.Collections.Generic;
using Order.Processor;

namespace Order.Tests
{
    public class FakePurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly List<int> _ProcessedOrders;

        public FakePurchaseOrderProcessor()
        {
            _ProcessedOrders = new List<int>();
        }

        public IEnumerable<int> ProcessedOrders => _ProcessedOrders;

        public void HandlePurchaseOrder(IPurchaseOrder purchaseOrder)
        {
            if (!_ProcessedOrders.Any(pId => pId == purchaseOrder.Id))
            {
                _ProcessedOrders.Add(purchaseOrder.Id);
            }
        }
    }
}
