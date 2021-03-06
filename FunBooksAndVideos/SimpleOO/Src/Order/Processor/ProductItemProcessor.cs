﻿using Shipping;
using System;

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
            if (item.Type != ItemLineType.Product)
            {
                throw new Exception("Item must be ItemLineType.Product");
            }
            _ShippingService.GenerateShippingLabel(customerId, item.Description);
        }
    }

}