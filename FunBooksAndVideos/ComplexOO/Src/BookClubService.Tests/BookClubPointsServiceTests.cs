using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using MediatR;
using Moq;
using OrderService.Core.Messages;
using OrderService.Core;
using System.Threading;
using System;

namespace BookClubService.Tests
{
    public class BookClubPointsServiceTests
    {
        [Fact]
        public async Task BookClubPointsServiceHandlesProcessedPurchasedOrderForExistingMembership()
        {
            int customerId = 344656;
            AwardedCustomerPoints awardedCustomerPoints = new AwardedCustomerPoints();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(awardedCustomerPoints)
                .Verifiable("Awarded book club membership points.");

            ProcessedPurchaseOrder processedPurchaseOrder = new ProcessedPurchaseOrder
            {
                CustomerId = customerId,
                PurchaseOrderId = 4567890,
                Items = new List<ItemLineRequest>
                {
                    new ItemLineRequest {Description = "Comprehensive First Aid Training", Type = ItemLineType.Product, Category = ItemLineCategory.Book },
                    new ItemLineRequest {Description = "The Girl on the Train", Type = ItemLineType.Product, Category = ItemLineCategory.Video },
                }
            };

            IBookClubMembershipRepository fakeRepo = GetFakeBookClubMembershipRepository(BookClubMembership.Create(customerId));

            BookClubPointsService sut = new BookClubPointsService(mockMediator.Object, fakeRepo);

            await sut.Handle(processedPurchaseOrder);

            mockMediator.Verify(m => m.Send(It.Is<AwardCustomerPoints>(a => a.Points == 5), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task BookClubPointsServiceHandlesProcessedPurchasedOrderForNewMembership()
        {
            int customerId = 344656;
            AwardedCustomerPoints awardedCustomerPoints = new AwardedCustomerPoints();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(awardedCustomerPoints)
                .Verifiable("Awarded book club membership points.");

            ProcessedPurchaseOrder processedPurchaseOrder = new ProcessedPurchaseOrder
            {
                CustomerId = customerId,
                PurchaseOrderId = 4567890,
                Items = new List<ItemLineRequest>
                {
                    new ItemLineRequest
                    {
                        Description = "Comprehensive First Aid Training",
                        Type = ItemLineType.Product,
                        Category = ItemLineCategory.Book
                    },
                    new ItemLineRequest
                    {
                        Description = "The Girl on the Train",
                        Type = ItemLineType.Product,
                        Category = ItemLineCategory.Video
                    },
                    new ItemLineRequest
                    {
                        Description = "Book Club Membership",
                        Type = ItemLineType.Membership,
                        Category = ItemLineCategory.Book
                    },
                    new ItemLineRequest
                    {
                        Description = "Clean Code",
                        Type = ItemLineType.Product,
                        Category = ItemLineCategory.Book
                    }
                }
            };

            IBookClubMembershipRepository fakeRepo = GetFakeBookClubMembershipRepository(null);

            BookClubPointsService sut = new BookClubPointsService(mockMediator.Object, fakeRepo);

            await sut.Handle(processedPurchaseOrder);

            mockMediator.Verify(m => m.Send(It.Is<AwardCustomerPoints>(acp => acp.Points == 10), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task BookClubPointsServiceHandlesProcessedPurchasedOrderForNoMembership()
        {
            int customerId = 344656;
            AwardedCustomerPoints awardedCustomerPoints = new AwardedCustomerPoints();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(awardedCustomerPoints)
                .Verifiable("Awarded book club membership points.");

            ProcessedPurchaseOrder processedPurchaseOrder = new ProcessedPurchaseOrder
            {
                CustomerId = customerId,
                PurchaseOrderId = 4567890,
                Items = new List<ItemLineRequest>
                {
                    new ItemLineRequest {Description = "Comprehensive First Aid Training", Type = ItemLineType.Product },
                    new ItemLineRequest {Description = "The Girl on the Train", Type = ItemLineType.Product },
                }
            };

            IBookClubMembershipRepository fakeRepo = GetFakeBookClubMembershipRepository(null);

            BookClubPointsService sut = new BookClubPointsService(mockMediator.Object, fakeRepo);

            await sut.Handle(processedPurchaseOrder);

            mockMediator.Verify(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        private IBookClubMembershipRepository GetFakeBookClubMembershipRepository(BookClubMembership bookClubMembership)
        {
            IBookClubMembershipRepository repository = new FakeBookClubMembershipRepository();
            if (bookClubMembership != null)
                repository.Save(bookClubMembership);
            return repository;
        }
    }

    public class BookClubMembershipTests
    {
        [Fact]
        public void BookClubMembershipCreate()
        {
            int customerId = 344656;

            BookClubMembership sut = BookClubMembership.Create(customerId);

            sut.Id.ShouldBe(customerId);
        }
    }
}
