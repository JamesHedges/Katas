using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using OrderService.Core.Messages;
using OrderProcessorService;
using Moq;
using MediatR;
using Order.Services.Core;

namespace OrderProcessorService.Tests
{
    public class OrderProcessorTests
    {
        [Fact]
        public void OrderProcessorHandlesAcceptPurchaseOrder()
        {
            var mockMediator = new Mock<IMediator>();
            AcceptPurchaseOrder command = new AcceptPurchaseOrder
            {
                CustomerId = 3344656,
                PurchaseOrderId = 4567890,
                Items = new List<ItemLineRequest>
                {
                    new ItemLineRequest { Description = "Comprehensive First Aid Training", Type = ItemLineType.Product }
                }
            };
            AcceptedPurchaseOrder reply;

            OrderProcessor sut = new OrderProcessor(mockMediator.Object);

            reply = sut.Handle(command);

            reply.Accepted.ShouldBeTrue();
        }
    }
}
