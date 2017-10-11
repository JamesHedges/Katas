namespace Order.Processor
{
    public interface IItemProcessor
    {
        void HandlePurchaseOrderItem(int customerId, IItemLine item);
    }

}