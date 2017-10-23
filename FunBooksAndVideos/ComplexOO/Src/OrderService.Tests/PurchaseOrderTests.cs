using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;
using System.Threading.Tasks;
using System.Threading;

namespace OrderService.Tests
{
    public class PurchaseOrderTests
    {
        [Fact]
        public void CreatePurchaseOrder()
        {
            PurchaseOrder sut;
            int orderId = 3344656;
            decimal total = 48.5m;
            int customerId = 4567890;
            List<ItemLine> items = new List<ItemLine>
            {
                new ItemLine("Comprehensive First Aid Training", ItemLineType.Product),
                new ItemLine("The Girl on the Train", ItemLineType.Product),
                new ItemLine("Book Clum Membership", ItemLineType.Membership),
            };
            var mockMediator = new Mock<IMediator>();

            sut = PurchaseOrder.Create(orderId, total, customerId, items, mockMediator.Object);

            sut.ShouldNotBeNull();
            sut.Id.ShouldBeGreaterThan(0);
            sut.Id.ShouldBe(orderId);
            sut.Total.ShouldBe(total);
            sut.CustomerId.ShouldBe(customerId);
            sut.ItemLines.Count().ShouldBe(items.Count());

            bool allMatch = sut.ItemLines.All(l => items.Contains(l));
            allMatch.ShouldBeTrue();
        }

        [Fact]
        public async Task PurchaseOrderIsAccepted()
        {
            AcceptedPurchaseOrder accepted = new AcceptedPurchaseOrder { Accepted = true };
            bool publishedAccepted = false;

            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AcceptPurchaseOrder>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accepted)
                .Verifiable("Sent AcceptPurchaseOrder command.");

            mockMediator.Setup(m => m.Publish(It.IsAny<ProcessedPurchaseOrder>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("Published ProcessedPurchase order notification.");

            PurchaseOrder sut = CreateTestPurchaseOrder(mockMediator.Object);

            await sut.Accept();

            mockMediator.Verify(m => m.Send(It.IsAny<AcceptPurchaseOrder>(), It.IsAny<CancellationToken>()), Times.Once());
            mockMediator.Verify(m => m.Publish(It.IsAny<ProcessedPurchaseOrder>(), It.IsAny<CancellationToken>()), Times.Once);
            sut.Accepted.ShouldBeTrue();
        }

        private PurchaseOrder CreateTestPurchaseOrder(IMediator mediator)
        {
            int orderId = 3344656;
            decimal total = 48.5m;
            int customerId = 4567890;
            List<ItemLine> items = new List<ItemLine>
            {
                new ItemLine("Comprehensive First Aid Training", ItemLineType.Product),
                new ItemLine("The Girl on the Train", ItemLineType.Product),
                new ItemLine("Book Clum Membership", ItemLineType.Membership),
            };

            return CreateTestPurchaseOrder(mediator, orderId, total, customerId, items);
        }

        private PurchaseOrder CreateTestPurchaseOrder(IMediator mediator, int orderId, decimal total, int customerId, List<ItemLine> items)
        {
            PurchaseOrder sut;

            return PurchaseOrder.Create(orderId, total, customerId, items, mediator);
        }
    }

    public class PurchaseOrderRepositoryTests
    {
        [Fact]
        public static void PurchaseOrderRepositoryGetNextId()
        {
            PurchaseOrderRepository repo;
            int id;

            id = PurchaseOrderRepository.GetNextId();

            id.ShouldBeGreaterThan(0);
        }
    }
}
