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

    public class AcceptedPurchaseOrder : INotification
    {
        public bool Accepted { get; set; }
    }

    public class ProcessedPurchaseOrder : INotification
    {
        public int CustomerId { get; set; }
        public int PurchaseOrderId { get; set; }
        public IEnumerable<ItemLineRequest> Items { get; set; }
    }

    public class AwardCustomerPoints : IRequest<AwardedCustomerPoints>
    {
        public int CustomerId { get; set; }
        public int Points { get; set; }
    }

    public class AwardedCustomerPoints
    {
        public bool AwardedPoints { get; set; }
    }
}
