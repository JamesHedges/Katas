using System;
using Membership;

namespace Order.Processor
{
    public class MembershipItemProcessor : IItemProcessor
    {
        private readonly IMembershipService _MembershipService;

        public MembershipItemProcessor(IMembershipService membershipService)
        {
            _MembershipService = membershipService;
        }

        public void HandlePurchaseOrderItem(int customerId, IItemLine item)
        {
            if (item.Type != ItemLineType.Membership)
            {
                throw new Exception("Item must be ItemLineType.Membership");
            }
            _MembershipService.ActivateMembership(customerId, item.Description);
        }
    }

}