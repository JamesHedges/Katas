using System;
using MediatR;
using System.Collections.Generic;

namespace OrderService.Core.Messages
{
    public class AcceptPurchaseOrder : IRequest<AcceptedPurchaseOrder>
    {
        public int CustomerId { get; set; }
        public int PurchaseOrderId { get; set; }
        public IEnumerable<ItemLineRequest> Items { get; set; }
    }

    public class AcceptedPurchaseOrder
    {
        public bool Accepted { get; set; }
    }

    public class AcceptingPurchaseOrderItemLine : INotification
    {
        public int CustomerId { get; set; }
        public int PurchaseOrderId { get; set; }
        public ItemLineRequest Item { get; set; }
    }
}
