using Xunit;
using Shouldly;
using OrderService.Core;

namespace OrderService.Tests
{
    public class ItemLineTests
    {
        [Fact]
        public void ItemLineCreate()
        {
            ItemLine sut;
            string itemDesc = "TestLineItem";

            sut = new ItemLine(itemDesc, ItemLineType.Product);

            sut.ShouldNotBeNull();
            sut.Description.ShouldBe(itemDesc);
            sut.Type.ShouldBe(ItemLineType.Product);
        }

        [Fact]
        public void ItemLineEqualityIsEqual()
        {
            string itemDesc = "TestLineItem";
            ItemLine sut;
            ItemLine compareSut;
            bool areEqual;
            bool equalsAreEqual;

            sut = new ItemLine(itemDesc, ItemLineType.Product);
            compareSut = new ItemLine(itemDesc, ItemLineType.Product);

            areEqual = sut == compareSut;
            equalsAreEqual = sut.Equals(compareSut);

            areEqual.ShouldBeTrue();
            equalsAreEqual.ShouldBeTrue();
        }

        [Fact]
        public void ItemLineNotEqualityIsNotEqual()
        {
            string itemDesc = "TestLineItem";
            ItemLine sut;
            ItemLine compareSut1;
            ItemLine compareSut2;
            bool areNotEqual1;
            bool areNotEqual2;

            sut = new ItemLine(itemDesc, ItemLineType.Product);
            compareSut1 = new ItemLine("New Item", ItemLineType.Product);
            compareSut2 = new ItemLine(itemDesc, ItemLineType.Membership);

            areNotEqual1 = sut != compareSut1;
            areNotEqual2 = sut != compareSut2;

            areNotEqual1.ShouldBeTrue();
            areNotEqual2.ShouldBeTrue();
        }
    }
}
