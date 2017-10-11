using System;
using System.Collections.Generic;

namespace Order
{
    public class PurchaseOrder
    {
        private static int _LastId;

        static PurchaseOrder()
        {
            Random random = new Random();
            _LastId = random.Next(0, 4999999);
        }

        private PurchaseOrder()
        {
            Id = NextId();
        }

        public int Id { get; }
        public decimal Total { get; private set; }
        public int CustomerId { get; private set; }
        public IEnumerable<ItemLine> ItemLines { get; private set; }

        public static PurchaseOrder Create(decimal total, int customerId, IEnumerable<ItemLine> itemLines)
        {
            PurchaseOrder po = new PurchaseOrder
            {
                Total = total,
                CustomerId = customerId,
                ItemLines = itemLines
            };

            return po;
        }

        private static int NextId()
        {
            return ++_LastId;
        }
    }

    public class ItemLine
    {
        public string Description { get; set; }
        public ItemLineType Type { get; set; }
    }

    public enum ItemLineType
    {
        Video,
        Book,
        BookClub
    }
}
