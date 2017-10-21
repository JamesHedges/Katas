using System;
using MediatR;
using OrderService.Core.Messages;
using OrderService.Core;

namespace OrderProcessorService.Items
{
    public class MembershipItemProcessor : IItemProcessor
    {
        private readonly IMediator _Mediator;

        public MembershipItemProcessor(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public void HandlePurchaseOrderItem(int customerId, ItemLineRequest item)
        {
            if (item.Type != ItemLineType.Membership)
            {
                throw new Exception("Item must be ItemLineType.Membership");
            }
            _Mediator.Send( new ActivateMembership { CustomerId = customerId, Item = item });
        }
    }

}