using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Order;
using Order.Processor;

namespace Order.Tests
{
    public class PurchaseOrderProcessorTests
    {
        [Fact]
        public void ProcessProductPurchaseOrder()
        {
            decimal total = 48.5m;
            int customerId = 4567890;
            List<IItemLine> itemLines = new List<IItemLine>
            {
                new ItemLine { Description = "Comprehensive First Aid Training", Type = ItemLineType.Product },
                new ItemLine { Description = "The Girl on the Train", Type = ItemLineType.Product },
                new ItemLine { Description = "Book Club Membership", Type = ItemLineType.Membership }
            };


            FakeItemProcessorFactory itemProcessorFactory = new FakeItemProcessorFactory();
            IPurchaseOrderProcessor orderProcessor = new PurchaseOrderProcessor(itemProcessorFactory);
            PurchaseOrder po = PurchaseOrder.Create(orderProcessor, total, customerId, itemLines);

            orderProcessor.HandlePurchaseOrder(po);

            itemProcessorFactory.ProcessedItems.Count().ShouldBe(itemLines.Count());
        }
    }

    public class FakeItemProcessorFactory : IItemProcessorFactory
    {
        private readonly List<IItemLine> _ProcessedItems;

        public FakeItemProcessorFactory()
        {
            _ProcessedItems = new List<IItemLine>();
        }

        public IEnumerable<IItemLine> ProcessedItems => _ProcessedItems;

        public IItemProcessor GetItemProcessor(ItemLineType itemLineType)
        {
            return new SpyItemProcessor(_ProcessedItems);
        }
    }

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
