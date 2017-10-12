namespace Order.Processor
{
    public interface IItemProcessorBuilder
    {
        IItemProcessor GetItemProcessor(ItemLineType itemLineType);
    }
}