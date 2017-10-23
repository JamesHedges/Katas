using MediatR;

namespace OrderService.Core.Messages
{
    public class AcceptingPurchaseOrderItemLine : INotification
    {
        public int CustomerId { get; set; }
        public int PurchaseOrderId { get; set; }
        public ItemLineRequest Item { get; set; }
    }
}
