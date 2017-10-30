using Xunit;
using Shouldly;
using Moq;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;

namespace VideoClubService.Tests
{
    public class VideoClubServiceTests
    {
        [Fact]
        public void VideoClubServiceActivateMembership()
        {
            AcceptingPurchaseOrderItemLine acceptingPurchaseOrderItemLine = new AcceptingPurchaseOrderItemLine
            {
                CustomerId = 3344656,
                Item = new ItemLineRequest { Description = "Video Club Membership", Type = ItemLineType.Membership, Category = ItemLineCategory.Video }
            };
            ActivatedMembership activatedMembership = new ActivatedMembership
            {
                Activated = true
            };

            var mockMediator = new Mock<IMediator>();
            IVideoClubMembershipRepository videoClubMembershipRepository = GetFakeVideoClubMembershipRepository();

            var sut = new VideoClubService(mockMediator.Object, videoClubMembershipRepository);

            sut.Handle(acceptingPurchaseOrderItemLine);

            videoClubMembershipRepository.Get(3344656).ShouldNotBeNull();
        }

        private IVideoClubMembershipRepository GetFakeVideoClubMembershipRepository()
        {
            var repository = new FakeVideoClubMembershipRepository();
            var newMembership = VideoClubMembership.Create(3344656);
            repository.Save(newMembership);
            return repository;
        }
    }
}
