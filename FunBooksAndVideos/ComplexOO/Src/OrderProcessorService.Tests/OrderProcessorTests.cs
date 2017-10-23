using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Shouldly;
using OrderService.Core.Messages;
using OrderProcessorService;
using Moq;
using MediatR;
using OrderService.Core;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessorService.Tests
{
    public class OrderProcessorTests
    {
        [Fact]
        public async Task OrderProcessorHandlesAcceptPurchaseOrder()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Publish(It.IsAny<AcceptingPurchaseOrderItemLine>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("Called for each item line");

            AcceptPurchaseOrder command = new AcceptPurchaseOrder
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Items = new List<ItemLineRequest>
                {
                    new ItemLineRequest { Description = "Comprehensive First Aid Training", Type = ItemLineType.Product },
                    new ItemLineRequest { Description = "The Girl on the Train", Type = ItemLineType.Product},
                    new ItemLineRequest { Description = "Book Clum Membership", Type = ItemLineType.Membership }
                }
            };
            AcceptedPurchaseOrder reply;

            OrderProcessorService sut = new OrderProcessorService(mockMediator.Object);

            reply = await sut.Handle(command);

            reply.Accepted.ShouldBeTrue();
            mockMediator.Verify(m => m.Publish(It.IsAny<AcceptingPurchaseOrderItemLine>(), It.IsAny<CancellationToken>()), Times.Exactly(command.Items.Count()));
        }
    }
}
