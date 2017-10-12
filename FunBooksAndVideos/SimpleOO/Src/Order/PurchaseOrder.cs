using Membership;
using Shipping;
using System;
using System.Collections.Generic;
using Order.Processor;

namespace Order
{
    public class PurchaseOrder : IPurchaseOrder
    {
        private static int _LastId;
        private readonly IPurchaseOrderProcessor _OrderProcessor;
        private PurchaseOrderStatus _PurchaseOrderStatus;

        static PurchaseOrder()
        {
            Random random = new Random();
            _LastId = random.Next(0, 4999999);
        }

        private PurchaseOrder(IPurchaseOrderProcessor orderProcessor)
        {
            _OrderProcessor = orderProcessor;
            Id = NextId();
            _PurchaseOrderStatus = PurchaseOrderStatus.Created;
        }

        public int Id { get; }
        public decimal Total { get; private set; }
        public int CustomerId { get; private set; }
        public IEnumerable<IItemLine> ItemLines { get; private set; }


        public static IPurchaseOrder Create(IPurchaseOrderProcessor orderProcessor, decimal total, int customerId, IEnumerable<IItemLine> itemLines)
        {
            PurchaseOrder po = new PurchaseOrder(orderProcessor)
            {
                Total = total,
                CustomerId = customerId,
                ItemLines = itemLines
            };

            return po;
        }

        // When a purchase order is accepted, then process it.
        public void Accept()
        {
            if (_PurchaseOrderStatus == PurchaseOrderStatus.Created)
            {
                _OrderProcessor.HandlePurchaseOrder(this);
                _PurchaseOrderStatus = PurchaseOrderStatus.Accepted;
            }
        }

        // In a production system, ID generation will
        // generate a unique value (GUID), use a persisted last ID,
        // or moved to a service.
        private static int NextId()
        {
            return ++_LastId;
        }
    }

    public enum PurchaseOrderStatus
    {
        Created,
        Accepted
    }
}
