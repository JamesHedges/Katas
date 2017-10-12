using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Shouldly;
using Order.Processor;
using Membership;
using Shipping;

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

            PurchaseOrder po = PurchaseOrder.Create(poProcessor, total, customerId, itemLines);

            po.ShouldNotBeNull();
            po.Id.ShouldBeGreaterThan(0);
            po.CustomerId.ShouldBe(customerId);
            po.Total.ShouldBe(total);
            po.ItemLines.Count().ShouldBe(itemLines.Count());
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

            PurchaseOrder po = PurchaseOrder.Create(orderProcessor, total, customerId, itemLines);
            po.Accept();

            orderProcessor.ProcessedOrders.Any(pId => pId == po.Id).ShouldBeTrue();
        }
    }

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

    public class FakeShippingService : IShippingService
    {
        public void GenerateShippingLabel(int customerId, string itemLine)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeMembershipService : IMembershipService
    {
        public void ActivateMembership(int customerId, string itemLine)
        {
            throw new NotImplementedException();
        }
    }
}
