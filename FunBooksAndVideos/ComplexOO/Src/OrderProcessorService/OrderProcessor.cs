using System;
using System.Threading.Tasks;
using MediatR;
using OrderService.Core.Messages;

namespace OrderProcessorService
{
    public class OrderProcessorService : IAsyncRequestHandler<AcceptPurchaseOrder, AcceptedPurchaseOrder>
    {
        private readonly IMediator _Mediator;

        public OrderProcessorService(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public async Task<AcceptedPurchaseOrder> Handle(AcceptPurchaseOrder message)
        {
            foreach(var item in message.Items)
            {
                AcceptingPurchaseOrderItemLine itemEvent = new AcceptingPurchaseOrderItemLine
                {
                    CustomerId = message.CustomerId,
                    PurchaseOrderId = message.PurchaseOrderId,
                    Item = item
                };
                await _Mediator.Publish(itemEvent);
            }
            return new AcceptedPurchaseOrder { Accepted = true };
        }
    }
}
