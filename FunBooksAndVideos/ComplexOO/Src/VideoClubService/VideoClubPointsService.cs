using MediatR;
using OrderService.Core;
using OrderService.Core.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClubService
{
    public class VideoClubPointsService
    {
        private readonly IMediator _Mediator;
        private readonly IVideoClubMembershipRepository _Repository;
        private const int _PointsPerVideo = 5;

        public VideoClubPointsService(IMediator mediator, IVideoClubMembershipRepository repository)
        {
            _Mediator = mediator;
            _Repository = repository;
        }

        public async Task Handle(ProcessedPurchaseOrder notification)
        {
            if (OrderHasVideos(notification.Items))
            {
                if (OrderHasVideoClubMembership(notification.Items) || CustomerHasMembership(notification.CustomerId))
                {
                    int points = GetVideoPoints(notification.Items);
                    AwardCustomerPoints awardCustomerPoints = new AwardCustomerPoints
                    {
                        CustomerId = notification.CustomerId,
                        Points = points
                    };
                    var response = await _Mediator.Send(awardCustomerPoints);
                }
            }
        }

        private int GetVideoPoints(IEnumerable<ItemLineRequest> items)
        {
            return items.Where(i => i.Type == ItemLineType.Product && i.Category == ItemLineCategory.Video).Sum(i => _PointsPerVideo);
        }

        private bool OrderHasVideos(IEnumerable<ItemLineRequest> items)
        {
            return items.Any(i => i.Type == ItemLineType.Product && i.Category == ItemLineCategory.Video);
        }

        private bool OrderHasVideoClubMembership(IEnumerable<ItemLineRequest> items)
        {
            return items.Any(i => i.Type == ItemLineType.Membership && i.Category == ItemLineCategory.Video);
        }

        private bool CustomerHasMembership(int customerId)
        {
            var hasMembership = _Repository.Get().Any(bcm => bcm.Id == customerId);
            return hasMembership;
        }
    }
}
