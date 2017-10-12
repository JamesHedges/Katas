namespace Order.Processor
{
    public interface IPurchaseOrderProcessor
    {
        void HandlePurchaseOrder(IPurchaseOrder purchaseOrder);
    }


}