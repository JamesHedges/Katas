using System;
using Membership;

namespace Order.Tests
{
    public class FakeMembershipService : IMembershipService
    {
        public void ActivateMembership(int customerId, string itemLine)
        {
            throw new NotImplementedException();
        }
    }
}
