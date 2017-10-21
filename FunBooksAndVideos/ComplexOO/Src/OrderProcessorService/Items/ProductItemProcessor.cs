using System;
using OrderService.Core.Messages;
using MediatR;
using OrderService.Core;
using System.Threading.Tasks;

namespace OrderProcessorService.Items
{
    public class ProductItemProcessor : IAsyncNotificationHandler<AcceptingPurchaseOrderItemLine>
    {
        private readonly IMediator _Mediator;

        public ProductItemProcessor(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public async Task Handle(AcceptingPurchaseOrderItemLine notification)
        {
            if (notification.Item.Type == ItemLineType.Product)
            {
                GenerateShippingLabel request = new GenerateShippingLabel
                {
                    CustomerId = notification.CustomerId,
                    Item = notification.Item
                };
                var response = await _Mediator.Send(request);
            }
        }
    }

}