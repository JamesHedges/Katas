using Xunit;
using Moq;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace VideoClubService.Tests
{
    public class VideoClubPointsServiceTests
    {
        [Fact]
        public async Task VideoClubPointsServiceHandlesProcessedPurchasedOrderForExistingMembership()
        {
            int customerId = 344656;
            AwardedCustomerPoints awardedCustomerPoints = new AwardedCustomerPoints();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(awardedCustomerPoints)
                .Verifiable("Awarded Video club membership points.");

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

            IVideoClubMembershipRepository fakeRepo = GetFakeVideoClubMembershipRepository(VideoClubMembership.Create(customerId));

            VideoClubPointsService sut = new VideoClubPointsService(mockMediator.Object, fakeRepo);

            await sut.Handle(processedPurchaseOrder);

            mockMediator.Verify(m => m.Send(It.Is<AwardCustomerPoints>(a => a.Points == 5), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task VideoClubPointsServiceHandlesProcessedPurchasedOrderForNewMembership()
        {
            int customerId = 344656;
            AwardedCustomerPoints awardedCustomerPoints = new AwardedCustomerPoints();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(awardedCustomerPoints)
                .Verifiable("Awarded Video club membership points.");

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
                        Description = "Video Club Membership",
                        Type = ItemLineType.Membership,
                        Category = ItemLineCategory.Video
                    },
                    new ItemLineRequest
                    {
                        Description = "Clean Code Video",
                        Type = ItemLineType.Product,
                        Category = ItemLineCategory.Video
                    }
                }
            };

            IVideoClubMembershipRepository fakeRepo = GetFakeVideoClubMembershipRepository(null);

            VideoClubPointsService sut = new VideoClubPointsService(mockMediator.Object, fakeRepo);

            await sut.Handle(processedPurchaseOrder);

            mockMediator.Verify(m => m.Send(It.Is<AwardCustomerPoints>(acp => acp.Points == 10), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task VideoClubPointsServiceHandlesProcessedPurchasedOrderForNoMembership()
        {
            int customerId = 344656;
            AwardedCustomerPoints awardedCustomerPoints = new AwardedCustomerPoints();
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(awardedCustomerPoints)
                .Verifiable("Awarded Video club membership points.");

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

            IVideoClubMembershipRepository fakeRepo = GetFakeVideoClubMembershipRepository(null);

            VideoClubPointsService sut = new VideoClubPointsService(mockMediator.Object, fakeRepo);

            await sut.Handle(processedPurchaseOrder);

            mockMediator.Verify(m => m.Send(It.IsAny<AwardCustomerPoints>(), It.IsAny<CancellationToken>()), Times.Never);
        }

        private IVideoClubMembershipRepository GetFakeVideoClubMembershipRepository(VideoClubMembership VideoClubMembership)
        {
            IVideoClubMembershipRepository repository = new FakeVideoClubMembershipRepository();
            if (VideoClubMembership != null)
                repository.Save(VideoClubMembership);
            return repository;
        }
    }
}
