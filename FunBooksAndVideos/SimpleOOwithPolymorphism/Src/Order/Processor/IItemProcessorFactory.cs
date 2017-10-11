namespace Order.Processor
{
    public interface IItemProcessorFactory
    {
        IItemProcessor GetItemProcessor(ItemLineType itemLineType);
    }
}