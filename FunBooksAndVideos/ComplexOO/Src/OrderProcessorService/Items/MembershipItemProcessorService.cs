using System;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;
using System.Threading.Tasks;

namespace OrderProcessorService.Items
{
    public class MembershipItemProcessorService : IAsyncNotificationHandler<AcceptingPurchaseOrderItemLine>
    {
        private readonly IMediator _Mediator;

        public MembershipItemProcessorService(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public async Task Handle(AcceptingPurchaseOrderItemLine notification)
        {
            if (notification.Item.Type == ItemLineType.Membership)
            {
                ActivateMembership request = new ActivateMembership
                {
                    CustomerId = notification.CustomerId,
                    Item = notification.Item
                };
                var response = await _Mediator.Send(request);
            }
        }
    }

}