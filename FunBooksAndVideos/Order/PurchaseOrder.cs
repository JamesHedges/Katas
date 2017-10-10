using System;
using System.Collections.Generic;
using DDD.Shared.Domain;

namespace FunBooksAndVideo.Order
{
    public class PurchaseOrder : Entity<int>
    {
        protected PurchaseOrder()
            : base()
        {
        }

        public PurchaseOrder(int id)
            : base(id)
        {
        }

        public static PurchaseOrder Create(int id, int customerId, decimal totalPrice, IEnumerable<ItemLine> itemLines)
        {
            PurchaseOrder po = new PurchaseOrder
            {
                Id = id,
                CustomerId = customerId,
                TotalPrice = totalPrice,
                ItemLines = itemLines
            };

            return po;
        }

        public int CustomerId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public IEnumerable<ItemLine> ItemLines { get; private set; }
        public int Id { get; private set; }
    }

    public class ItemLine
    {
        public ItemLine(OrderItemType type, string description)
        {
            Type = type;
            Description = description;
        }

        public OrderItemType Type { get; }
        public string Description { get; }
    }

    public enum OrderItemType
    {
        Book,
        Video,
        Membership
    }
}
