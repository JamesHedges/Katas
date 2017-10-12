using System;
using System.Diagnostics;

namespace Membership
{
    public class MembershipService : IMembershipService
    {
        public void ActivateMembership(int customerId, string itemLine)
        {
            Debug.WriteLine($"Activating membership {itemLine} for customer ID: {customerId}");
        }
    }
}
