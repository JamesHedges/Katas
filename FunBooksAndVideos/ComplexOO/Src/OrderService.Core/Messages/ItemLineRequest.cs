using OrderService.Core;

namespace OrderService.Core.Messages
{
    public class ItemLineRequest
    {
        public string Description { get; set; }
        public ItemLineType Type { get; set; }
        public ItemLineCategory Category { get; set; }
    }
}
