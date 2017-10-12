namespace Order.Processor
{
    public class PurchaseOrderProcessor : IPurchaseOrderProcessor
    {
        private readonly IItemProcessorBuilder _ItemProcessorFactory;

        public PurchaseOrderProcessor(IItemProcessorBuilder itemProcessorFactory)
        {
            _ItemProcessorFactory = itemProcessorFactory;
        }

        public void HandlePurchaseOrder(IPurchaseOrder purchaseOrder)
        {
            foreach(var item in purchaseOrder.ItemLines)
            {
                var itemProcessor = _ItemProcessorFactory.GetItemProcessor(item.Type);
                itemProcessor.HandlePurchaseOrderItem(purchaseOrder.CustomerId, item);
            }
        }
    }

}