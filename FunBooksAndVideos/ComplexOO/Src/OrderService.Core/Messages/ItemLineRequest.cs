using OrderService.Core;

namespace OrderService.Core.Messages
{
    public class ItemLineRequest
    {
        public ItemLineType Type { get; set; }
        public string Description { get; set; }
    }
}
