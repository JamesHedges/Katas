using MediatR;
using OrderService.Core.Messages;

namespace OrderProcessorService.Items
{
    public class FirstAidVideoProcessor : ProductItemProcessor
    {
        public FirstAidVideoProcessor(IMediator mediator)
            : base (mediator)
        {

        }

        public override void HandlePurchaseOrderItem(int customerId, ItemLineRequest item)
        {
            base.HandlePurchaseOrderItem(customerId, item);
        }
    }
}