using System.Threading.Tasks;
using MediatR;
using OrderService.Core;
using OrderService.Core.Messages;

namespace VideoClubService
{
    public class VideoClubService : 
        INotificationHandler<AcceptingPurchaseOrderItemLine>
    {
        private readonly IMediator _Mediator;
        private readonly IVideoClubMembershipRepository _Repository;

        public VideoClubService(IMediator mediator, IVideoClubMembershipRepository repository)
        {
            _Mediator = mediator;
            _Repository = repository;
        }

        public void Handle(AcceptingPurchaseOrderItemLine notification)
        {
            if (notification.Item.Type == ItemLineType.Membership && notification.Item.Category == ItemLineCategory.Video)
            {
                var membership = _Repository.Get(notification.CustomerId);
                if (membership == null)
                {
                    membership = VideoClubMembership.Create(notification.CustomerId);
                }
            }
        }
    }
}
