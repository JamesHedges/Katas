using System;
using System.Threading.Tasks;
using MediatR;
using OrderService.Core.Messages;
using DDD.Core.Repository;
using OrderService.Core;

namespace BookClubService
{
    public class BookClubService :
        INotificationHandler<AcceptingPurchaseOrderItemLine>
    {
        private readonly IMediator _Mediator;
        private readonly IBookClubMembershipRepository _Repository;

        public BookClubService(IMediator mediator, IBookClubMembershipRepository repository)
        {
            _Mediator = mediator;
            _Repository = repository;
        }

        public void Handle(AcceptingPurchaseOrderItemLine message)
        {
            if (message.Item.Type == ItemLineType.Membership && message.Item.Category == ItemLineCategory.Book)
            {
                var membership = _Repository.Get(message.CustomerId);
                if (membership == null)
                {
                    membership = BookClubMembership.Create(message.CustomerId);
                }
            }
        }
    }
}
