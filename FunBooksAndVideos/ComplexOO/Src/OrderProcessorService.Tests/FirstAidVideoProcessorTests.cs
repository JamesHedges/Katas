using System.Threading.Tasks;
using Xunit;
using Moq;
using MediatR;
using System.Threading;
using OrderService.Core.Messages;
using OrderService.Core;
using OrderProcessorService.Items;
using System;
using System.Diagnostics;

namespace OrderProcessorService.Tests
{
    public class FirstAidVideoProcessorTests
    {
        [Fact]
        public async Task FirstAidVideoProcessorHandlesFirstAidVideo()
        {
            AddedItemLineToPurchaseOrder response = new AddedItemLineToPurchaseOrder { Added = true };
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddItemLineToPurchaseOrder>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response)
                .Verifiable("Sends request to add basic first aid video to purchase order.");

            //Task task = new Task();
            mockMediator.Setup(m => m.Publish(It.IsAny<AcceptingPurchaseOrderItemLine>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("Publishes AcceptingPurchaseOrderItemLine event for added item");


            AcceptingPurchaseOrderItemLine item = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Item = new ItemLineRequest { Description = "Comprehensive First Aid Training", Type = ItemLineType.Product }
            };

            var sut = new FirstAidVideoProcessorService(mockMediator.Object);

            await sut.Handle(item);

            mockMediator.Verify(m => m.Send(It.IsAny<AddItemLineToPurchaseOrder>(), It.IsAny<CancellationToken>()), Times.Once);
            mockMediator.Verify(m => m.Publish(It.IsAny<AcceptingPurchaseOrderItemLine>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task FirstAidVideoProcessorHandlesNonFirstAidVideo()
        {
            AddedItemLineToPurchaseOrder response = new AddedItemLineToPurchaseOrder { Added = true };
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddItemLineToPurchaseOrder>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response)
                .Verifiable("Does not Send a request to add basic first aid video to purchase order.");


            AcceptingPurchaseOrderItemLine item = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Item = new ItemLineRequest { Description = "The Girl on the Train", Type = ItemLineType.Product }
            };

            var sut = new FirstAidVideoProcessorService(mockMediator.Object);

            await sut.Handle(item);

            mockMediator.Verify(m => m.Send(It.IsAny<AddItemLineToPurchaseOrder>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task FirstAidVideoProcessorHandlesNonProductType()
        {
            AddedItemLineToPurchaseOrder response = new AddedItemLineToPurchaseOrder { Added = true };
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AddItemLineToPurchaseOrder>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response)
                .Verifiable("Does not Send a request to add basic first aid video to purchase order.");


            AcceptingPurchaseOrderItemLine item = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Item = new ItemLineRequest { Description = "Comprehensive First Aid Training", Type = ItemLineType.Membership }
            };

            var sut = new FirstAidVideoProcessorService(mockMediator.Object);

            await sut.Handle(item);

            mockMediator.Verify(m => m.Send(It.IsAny<AddItemLineToPurchaseOrder>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
