using MediatR;

namespace OrderService.Core.Messages
{
    public class AddItemLineToPurchaseOrder : IRequest<AddedItemLineToPurchaseOrder>
    {
        public int PurchaseOrderId { get; set; }
        public ItemLineRequest ItemLine { get; set; }
    }

    public class AddedItemLineToPurchaseOrder
    {
        public bool Added { get; set; }
    }
}
