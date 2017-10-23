using System;
using System.Threading.Tasks;
using MediatR;
using OrderService.Core.Messages;
using DDD.Core.Repository;

namespace BookClubService
{
    public class BookClubService : IRequestHandler<ActivateMembership, ActivatedMembership>
    {
        private readonly IMediator _Mediator;
        private readonly IBookClubMembershipRepository _Repository;

        public BookClubService(IMediator mediator, IBookClubMembershipRepository repository)
        {
            _Mediator = mediator;
            _Repository = repository;
        }

        public ActivatedMembership Handle(ActivateMembership message)
        {
            var membership = _Repository.Get(message.CustomerId);
            if (membership == null)
            {
                membership = BookClubMembership.Create(message.CustomerId);
            }
            return new ActivatedMembership { Activated = true };
        }


    }
}
