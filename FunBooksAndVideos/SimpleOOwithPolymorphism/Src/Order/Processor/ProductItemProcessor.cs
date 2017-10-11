using Shipping;

namespace Order.Processor
{
    public class ProductItemProcessor : IItemProcessor
    {
        private readonly IShippingService _ShippingService;

        public ProductItemProcessor(IShippingService shippingService)
        {
            _ShippingService = shippingService;
        }

        public void HandlePurchaseOrderItem(int customerId, IItemLine item)
        {
            _ShippingService.GenerateShippingLabel(customerId, item.Description);
        }
    }

}