using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Order;

namespace Order.Tests
{
    public class PurchaseOrderTests
    {
        [Fact]
        public void CreatePurchaseOrder()
        {
            decimal total = 48.5m;
            int customerId = 4567890;
            List<ItemLine> itemLines = new List<ItemLine>
            {
                new ItemLine { Description = "Comprehensive First Aid Training", Type = ItemLineType.Video },
                new ItemLine { Description = "The Girl on the Train", Type = ItemLineType.Book },
                new ItemLine { Description = "Book Club Membership", Type = ItemLineType.BookClub },
            };

            PurchaseOrder po = PurchaseOrder.Create(total, customerId, itemLines);

            po.ShouldNotBeNull();
            po.Id.ShouldBeGreaterThan(0);
            po.CustomerId.ShouldBe(customerId);
            po.Total.ShouldBe(total);
            po.ItemLines.Count().ShouldBe(itemLines.Count());
        }
    }
}
