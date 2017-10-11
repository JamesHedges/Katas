using System;
using Shipping;
using Membership;

namespace Order.Processor
{
    public class ItemProcessorBuilder : IItemProcessorBuilder
    {
        private readonly IShippingService _ShippingService;
        private readonly IMembershipService _MembershipService;

        public ItemProcessorBuilder()
        {
            _ShippingService = new ShippingService();
            _MembershipService = new MembershipService();
        }

        public IItemProcessor GetItemProcessor(ItemLineType itemLineType)
        {
            switch (itemLineType)
            {
                case ItemLineType.Product:
                    return GetProductItemProcessor();
                    break;
                case ItemLineType.Membership:
                    return GetMembershipItemProcessor();
                    break;
                default:
                    throw new Exception("Invalid Line Item Type. Could not get item processor");
                    break;
            }
        }

        private IItemProcessor GetMembershipItemProcessor()
        {
            return new MembershipItemProcessor(_MembershipService);
        }

        private IItemProcessor GetProductItemProcessor()
        {
            return new ProductItemProcessor(_ShippingService);
        }
    }

}