using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;

namespace BookClubService
{
    public class BookClubPointsService : IAsyncNotificationHandler<ProcessedPurchaseOrder>
    {
        private readonly IMediator _Mediator;
        private readonly IBookClubMembershipRepository _Repository;
        private const int _PointsPerBook = 5;

        public BookClubPointsService(IMediator mediator, IBookClubMembershipRepository repository)
        {
            _Mediator = mediator;
            _Repository = repository;
        }

       public async Task Handle(ProcessedPurchaseOrder notification)
       {
           if (OrderHasBooks(notification.Items))
           {
               if (OrderHasBookClubMembership(notification.Items) || CustomerHasMembership(notification.CustomerId))
               {
                   int points = GetBookPoints(notification.Items);
                   AwardCustomerPoints awardCustomerPoints = new AwardCustomerPoints
                   {
                       CustomerId = notification.CustomerId,
                       Points = points
                   };
                   var response = await _Mediator.Send(awardCustomerPoints);
               }
           }
       }

        private int GetBookPoints(IEnumerable<ItemLineRequest> items)
        {
            return items.Where(i => i.Type == ItemLineType.Product && i.Category == ItemLineCategory.Book).Sum(i => _PointsPerBook);
        }

        private bool OrderHasBooks(IEnumerable<ItemLineRequest> items)
        {
            return items.Any(i => i.Type == ItemLineType.Product && i.Category == ItemLineCategory.Book);
        }

        private bool OrderHasBookClubMembership(IEnumerable<ItemLineRequest> items)
        {
            return items.Any(i => i.Type == ItemLineType.Membership && i.Category == ItemLineCategory.Book);
        }

        private bool CustomerHasMembership(int customerId)
        {
            var hasMembership = _Repository.Get().Any(bcm => bcm.Id == customerId);
            return hasMembership;
        }

    }
}
