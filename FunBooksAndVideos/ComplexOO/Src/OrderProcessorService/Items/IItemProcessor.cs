using OrderService.Core.Messages;

namespace OrderProcessorService.Items
{
    public interface IItemProcessor
    {
        void HandlePurchaseOrderItem(int customerId, ItemLineRequest item);
    }

}