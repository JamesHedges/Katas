using MediatR;

namespace OrderService.Core.Messages
{
    public class ActivateMembership : IRequest<ActivatedMembership>
    {
        public int CustomerId { get; set; }
        public ItemLineRequest Item { get; set; }
    }

    public class ActivatedMembership
    {
        public bool Activated { get; set; }
    }
}
