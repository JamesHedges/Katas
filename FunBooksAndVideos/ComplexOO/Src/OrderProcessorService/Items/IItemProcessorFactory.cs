using OrderService.Core.Messages;

namespace OrderProcessorService.Items
{
    public interface IItemProcessorBuilder
    {
        IItemProcessor GetItemProcessor(ItemLineRequest itemLine);
    }
}