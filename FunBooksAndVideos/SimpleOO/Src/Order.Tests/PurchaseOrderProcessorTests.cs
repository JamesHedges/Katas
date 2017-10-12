using System.Collections.Generic;
using System.Linq;
using Xunit;
using Shouldly;
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


            FakeItemProcessorBuilder itemProcessorFactory = new FakeItemProcessorBuilder();
            IPurchaseOrderProcessor orderProcessor = new PurchaseOrderProcessor(itemProcessorFactory);
            PurchaseOrder po = PurchaseOrder.Create(orderProcessor, total, customerId, itemLines);

            orderProcessor.HandlePurchaseOrder(po);

            itemProcessorFactory.ProcessedItems.Count().ShouldBe(itemLines.Count());
        }
    }

    public class FakeItemProcessorBuilder : IItemProcessorBuilder
    {
        private readonly List<IItemLine> _ProcessedItems;

        public FakeItemProcessorBuilder()
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
