using System;
using MediatR;
using OrderService.Core.Messages;

namespace OrderProcessorService
{
    public class OrderProcessor : IRequestHandler<AcceptPurchaseOrder, AcceptedPurchaseOrder>
    {
        private readonly IMediator _Mediator;

        public OrderProcessor(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public AcceptedPurchaseOrder Handle(AcceptPurchaseOrder message)
        {
            foreach(var item in message.Items)
            {
                AcceptingPurchaseOrderItemLine itemEvent = new AcceptingPurchaseOrderItemLine
                {
                    CustomerId = message.CustomerId,
                    PurchaseOrderId = message.PurchaseOrderId,
                    Item = item
                };
                _Mediator.Publish(itemEvent);
            }
            return new AcceptedPurchaseOrder { Accepted = true };
        }
    }
}
