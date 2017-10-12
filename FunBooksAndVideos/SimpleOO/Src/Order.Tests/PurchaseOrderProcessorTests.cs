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
        public void ProcessProductPurchaseOrderProcessesEachItemLine()
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
            IPurchaseOrder po = PurchaseOrder.Create(orderProcessor, total, customerId, itemLines);

            orderProcessor.HandlePurchaseOrder(po);

            itemProcessorFactory.ProcessedItems.Count().ShouldBe(itemLines.Count());
        }
    }
}
