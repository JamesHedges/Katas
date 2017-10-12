using System.Collections.Generic;
using Order.Processor;

namespace Order.Tests
{
    public class FakeItemProcessorBuilder : IItemProcessorBuilder
    {
        private readonly List<IItemLine> _ProcessedItems;

        public FakeItemProcessorBuilder()
        {
            _ProcessedItems = new List<IItemLine>();
        }

        public IEnumerable<IItemLine> ProcessedItems => _ProcessedItems;

        public IItemProcessor GetItemProcessor(ItemLineType itemLineType)
        {
            return new SpyItemProcessor(_ProcessedItems);
        }
    }
}
