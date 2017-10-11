using System.Collections.Generic;

namespace Order
{
    public interface IPurchaseOrder
    {
        int CustomerId { get; }
        int Id { get; }
        IEnumerable<IItemLine> ItemLines { get; }
        decimal Total { get; }

        void Accept();
    }
}