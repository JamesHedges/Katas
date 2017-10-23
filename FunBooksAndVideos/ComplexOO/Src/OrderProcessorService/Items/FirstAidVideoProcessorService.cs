using MediatR;
using OrderService.Core.Messages;
using MediatR;
using System.Threading.Tasks;
using OrderService.Core;

namespace OrderProcessorService.Items
{
    public class FirstAidVideoProcessorService : IAsyncNotificationHandler<AcceptingPurchaseOrderItemLine>
    {
        private readonly IMediator _Mediator;
        private const string ComprehensiveFirstAid = "Comprehensive First Aid Training";
        private readonly ItemLineRequest BasicFirstAid = new ItemLineRequest { Description = "Basic First Aid Training", Type = ItemLineType.Product };

        public FirstAidVideoProcessorService(IMediator mediator)
        {
            _Mediator = mediator;
        }

        public async Task Handle(AcceptingPurchaseOrderItemLine notification)
        {
            if (notification.Item.Type == ItemLineType.Product && notification.Item.Description == ComprehensiveFirstAid)
            {
                AddItemLineToPurchaseOrder request = new AddItemLineToPurchaseOrder
                {
                    PurchaseOrderId = notification.PurchaseOrderId,
                    ItemLine = BasicFirstAid
                };
                AddedItemLineToPurchaseOrder response = await _Mediator.Send(request);
                if (response.Added)
                {
                    AcceptingPurchaseOrderItemLine acceptNewItem = new AcceptingPurchaseOrderItemLine
                    {
                        CustomerId = notification.CustomerId,
                        PurchaseOrderId = notification.PurchaseOrderId,
                        Item = BasicFirstAid
                    };
                    await _Mediator.Publish(acceptNewItem);
                }
            }
        }
    }
}