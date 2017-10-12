using Xunit;
using Shouldly;
using Order.Processor;
using System.Linq;
using System;

namespace Order.Tests
{
    public class ProductItemProcessorTests
    {
        [Fact]
        public void ProductItemProcessorHandleProductItemLine()
        {
            int customerId = 4567890;
            ItemLine productItemLine = new ItemLine { Description = "The Gril on the Train", Type = ItemLineType.Product };
            SpyShippingService shippingService = new SpyShippingService();
            ProductItemProcessor itemProcessor = new ProductItemProcessor(shippingService);

            itemProcessor.HandlePurchaseOrderItem(customerId, productItemLine);
            shippingService.ProcessedItems.Any(pi => pi.Contains(productItemLine.Description)).ShouldBeTrue();

        }

        [Fact]
        public void ProductItemProcessorHandleMembershipItemLine()
        {
            int customerId = 4567890;
            ItemLine productItemLine = new ItemLine { Description = "Book Club Membership", Type = ItemLineType.Membership };
            SpyShippingService shippingService = new SpyShippingService();
            ProductItemProcessor itemProcessor = new ProductItemProcessor(shippingService);
            Exception result = null;

            result = Assert.Throws<Exception>(() => itemProcessor.HandlePurchaseOrderItem(customerId, productItemLine));

            result.ShouldNotBeNull();
            result.Message.ShouldBe("Item must be ItemLineType.Product");

        }
    }
}
