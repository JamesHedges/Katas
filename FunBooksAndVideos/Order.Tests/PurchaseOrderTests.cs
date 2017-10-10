using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FunBooksAndVideo.Order;
using DDD.Shared.Domain;
using Shouldly;
using FunBooksAndVideo.Order.Repository;

namespace FunBooksAndVideo.Order.Tests
{
    public class PurchaseOrderTests
    {
        [Fact]
        public void CreatePO()
        {
            int id = PurchaseOrderRepository.NextId();
            decimal totalPrice = 48.5m;
            int customerId = 4567890;
            IEnumerable<ItemLine> itemLines = new List<ItemLine>
            {
                new ItemLine (OrderItemType.Book, "The Girl on the Train"),
                new ItemLine (OrderItemType.Video, "Comprehensive First Aid Taining"),
                new ItemLine (OrderItemType.Membership, "Book Club Membership"),
            };

            PurchaseOrder po = PurchaseOrder.Create(id, customerId, totalPrice, itemLines);
            po.Id.ShouldBe(id);
            po.ShouldNotBeNull();
            po.ItemLines.Count().ShouldBe(itemLines.Count());
            po.CustomerId.ShouldBe(customerId);
            po.TotalPrice.ShouldBe(totalPrice);
            po.State.ShouldBe(EntityState.Inserted);
        }
    }
}
