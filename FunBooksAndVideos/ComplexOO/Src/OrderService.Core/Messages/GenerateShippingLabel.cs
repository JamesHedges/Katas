using MediatR;

namespace OrderService.Core.Messages
{
    public class GenerateShippingLabel : IRequest<GeneratedShippingLabel>
    {
        public int CustomerId { get; set; }
        public ItemLineRequest Item { get; set; }
    }

    public class GeneratedShippingLabel
    {
        public bool LabelGenerated { get; set; }
    }
}
