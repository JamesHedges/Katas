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
            _MembershipService.ActivateMembership(customerId, item.Description);
        }
    }

}