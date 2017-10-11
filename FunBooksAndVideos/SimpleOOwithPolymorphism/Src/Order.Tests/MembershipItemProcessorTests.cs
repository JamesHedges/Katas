using Xunit;
using Shouldly;
using Order.Processor;
using System.Linq;
using System;

namespace Order.Tests
{
    public class MembershipItemProcessorTests
    {
        [Fact]
        public void MembershipItemProcessorHandleMembershipItemLine()
        {
            int customerId = 4567890;
            ItemLine membershipItemLine = new ItemLine { Description = "The Gril on the Train", Type = ItemLineType.Membership };
            SpyMembershipService membershipService = new SpyMembershipService();
            MembershipItemProcessor itemProcessor = new MembershipItemProcessor(membershipService);

            itemProcessor.HandlePurchaseOrderItem(customerId, membershipItemLine);
            membershipService.ProcessedItems.Any(pi => pi.Contains(membershipItemLine.Description)).ShouldBeTrue();

        }

        [Fact]
        public void MembershipItemProcessorHandleProductItemLine()
        {
            int customerId = 4567890;
            ItemLine membershipItemLine = new ItemLine { Description = "Book Club Membership", Type = ItemLineType.Product };
            SpyMembershipService membershipService = new SpyMembershipService();
            MembershipItemProcessor itemProcessor = new MembershipItemProcessor(membershipService);
            Exception result = null;

            result = Assert.Throws<Exception>(() => itemProcessor.HandlePurchaseOrderItem(customerId, membershipItemLine));

            result.ShouldNotBeNull();
            result.Message.ShouldBe("Item must be ItemLineType.Membership");

        }
    }
}
