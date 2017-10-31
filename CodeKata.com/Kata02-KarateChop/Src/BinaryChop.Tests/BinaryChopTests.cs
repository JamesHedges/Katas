using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace BinaryChop.Tests
{
    public class BinaryChopTests
    {
        [Theory]
        [InlineData(-1, 3)]
        [InlineData(-1, 3, 1)]
        [InlineData(0, 1, 1)]

        [InlineData(0, 1, 1, 3, 5)]
        [InlineData(1, 3, 1, 3, 5)]
        [InlineData(2, 5, 1, 3, 5)]

        [InlineData(-1, 0, 1, 3, 5)]
        [InlineData(-1, 2, 1, 3, 5)]
        [InlineData(-1, 4, 1, 3, 5)]
        [InlineData(-1, 6, 1, 3, 5)]

        [InlineData(0, 1, 1, 3, 5, 7)]
        [InlineData(1, 3, 1, 3, 5, 7)]
        [InlineData(2, 5, 1, 3, 5, 7)]
        [InlineData(3, 7, 1, 3, 5, 7)]
        [InlineData(-1, 0, 1, 3, 5, 7)]
        [InlineData(-1, 2, 1, 3, 5, 7)]
        [InlineData(-1, 4, 1, 3, 5, 7)]
        [InlineData(-1, 6, 1, 3, 5, 7)]
        [InlineData(-1, 8, 1, 3, 5, 7)]
        public void TestTwo(int expected, int searchNumber, params int[] numbers)
        {
            SortedArray<int> sortedArray = new SortedArray<int>(numbers);
            IBinaryChopStrategy<int> searcher = new HalvingSearchStrategy();

            int result = sortedArray.Search(searchNumber, searcher);

            result.ShouldBe(expected);
        }
    }
}
