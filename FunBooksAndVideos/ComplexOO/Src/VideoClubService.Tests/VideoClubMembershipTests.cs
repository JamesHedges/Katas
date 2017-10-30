using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace VideoClubService.Tests
{
    public class VideoClubMembershipTests
    {
        [Fact]
        public void VideoClubMembershipCreate()
        {
            int customerId = 344656;

            VideoClubMembership sut = VideoClubMembership.Create(customerId);

            sut.Id.ShouldBe(customerId);
        }
    }
}
