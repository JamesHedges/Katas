using Xunit;
using Shouldly;
using Order.Processor;
using Membership;

namespace Order.Tests
{
    public class ItemProcessorBuilderTests
    {
        [Fact]
        public void BuildProductItemWithItemLineTypeProduct()
        {
            IItemProcessorBuilder builder = new ItemProcessorBuilder();

            var itemProcessor = builder.GetItemProcessor(ItemLineType.Product);

            itemProcessor.ShouldBeOfType(typeof(ProductItemProcessor));
        }

        [Fact]
        public void BuildMembershipItemWithItemLineTypeMembership()
        {
            IItemProcessorBuilder builder = new ItemProcessorBuilder();

            var itemProcessor = builder.GetItemProcessor(ItemLineType.Membership);

            itemProcessor.ShouldBeOfType(typeof(MembershipItemProcessor));
        }
    }
}
