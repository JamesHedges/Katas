using Xunit;
using Shouldly;

namespace BookClubService.Tests
{
    public class BookClubMembershipTests
    {
        [Fact]
        public void BookClubMembershipCreate()
        {
            int customerId = 344656;

            BookClubMembership sut = BookClubMembership.Create(customerId);

            sut.Id.ShouldBe(customerId);
        }
    }
}
