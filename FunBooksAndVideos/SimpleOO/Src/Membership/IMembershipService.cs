namespace Membership
{
    public interface IMembershipService
    {
        void ActivateMembership(int customerId, string itemLine);
    }
}
