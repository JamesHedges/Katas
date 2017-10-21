using System.Threading.Tasks;
using Xunit;
using OrderService.Core.Messages;
using Moq;
using MediatR;
using OrderService.Core;
using System.Threading;
using OrderProcessorService.Items;

namespace OrderProcessorService.Tests
{
    public class ProductItemProcessorTests
    {
        [Fact]
        public async Task ProductItemProcessorHandlesProductItem()
        {
            GeneratedShippingLabel response = new GeneratedShippingLabel { LabelGenerated = true };
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<GenerateShippingLabel>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response)
                .Verifiable("Called GenerateShippingLabel for the item");

            AcceptingPurchaseOrderItemLine item = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Item = new ItemLineRequest { Description = "The Girl on the Train", Type = ItemLineType.Product }
            };

            var sut = new ProductItemProcessorService(mockMediator.Object);

            await sut.Handle(item);

            mockMediator.Verify(m => m.Send(It.IsAny<GenerateShippingLabel>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task ProductItemProcessorDoesNotHandleMembershipItem()
        {
            GeneratedShippingLabel response = new GeneratedShippingLabel { LabelGenerated = true };
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<GenerateShippingLabel>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response)
                .Verifiable("Called GenerateShippingLabel for the item");

            AcceptingPurchaseOrderItemLine item = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Item = new ItemLineRequest { Description = "Book Club Membership", Type = ItemLineType.Membership }
            };

            var sut = new ProductItemProcessorService(mockMediator.Object);

            await sut.Handle(item);

            mockMediator.Verify(m => m.Send(It.IsAny<GenerateShippingLabel>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
