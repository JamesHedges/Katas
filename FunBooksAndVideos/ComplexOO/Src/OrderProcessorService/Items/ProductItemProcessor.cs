using System;
using OrderService.Core.Messages;
using MediatR;
using OrderService.Core;

namespace OrderProcessorService.Items
{
    public class ProductItemProcessor : IItemProcessor
    {
        private readonly IMediator _Mediator;

        public ProductItemProcessor(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public virtual void HandlePurchaseOrderItem(int customerId, ItemLineRequest item)
        {
            if (item.Type != ItemLineType.Product)
            {
                throw new Exception("Item must be ItemLineType.Product");
            }
            _Mediator.Send( new GenerateShippingLabel { CustomerId = customerId, Item = item });
        }
    }

}