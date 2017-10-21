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
            return new AcceptedPurchaseOrder { Accepted = true };
        }
    }
}
