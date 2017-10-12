using System.Collections.Generic;
using System.Linq;
using Xunit;
using Shouldly;
using Order.Processor;

namespace Order.Tests
{
    public class PurchaseOrderTests
    {
        [Fact]
        public void CreatePurchaseOrder()
        {
            decimal total = 48.5m;
            int customerId = 4567890;
            IPurchaseOrderProcessor poProcessor = new FakePurchaseOrderProcessor();
            List<IItemLine> itemLines = new List<IItemLine>
            {
                new ItemLine { Description = "Comprehensive First Aid Training", Type = ItemLineType.Product },
                new ItemLine { Description = "The Girl on the Train", Type = ItemLineType.Product },
                new ItemLine { Description = "Book Club Membership", Type = ItemLineType.Membership }
            };

            IPurchaseOrder po = PurchaseOrder.Create(poProcessor, total, customerId, itemLines);

            po.ShouldNotBeNull();
            po.Id.ShouldBeGreaterThan(0);
            po.CustomerId.ShouldBe(customerId);
            po.Total.ShouldBe(total);
            po.ItemLines.Count().ShouldBe(itemLines.Count());
        }

        [Fact]
        public void CreateMultiplePurchaseOrdersHaveUniqueIds()
        {
            IPurchaseOrderProcessor orderProcessor = new FakePurchaseOrderProcessor();
            IPurchaseOrder firstOrder;
            IPurchaseOrder secondOrder;

            firstOrder = PurchaseOrder.Create(orderProcessor, 100m, 1234567, new List<ItemLine> { new ItemLine { Description = "Item1", Type = ItemLineType.Product } });
            secondOrder = PurchaseOrder.Create(orderProcessor, 200m, 4567890, new List<ItemLine> { new ItemLine { Description = "Item2", Type = ItemLineType.Membership } });

            firstOrder.Id.ShouldNotBe(secondOrder.Id);
        }

        [Fact]
        public void AcceptPurchaseOrderProcessed()
        {
            decimal total = 48.5m;
            int customerId = 4567890;
            FakePurchaseOrderProcessor orderProcessor = new FakePurchaseOrderProcessor();
            List<IItemLine> itemLines = new List<IItemLine>
            {
                new ItemLine { Description = "Book Club Membership", Type = ItemLineType.Membership }
            };

            IPurchaseOrder po = PurchaseOrder.Create(orderProcessor, total, customerId, itemLines);
            po.Accept();

            orderProcessor.ProcessedOrders.Any(pId => pId == po.Id).ShouldBeTrue();
        }
    }
}
