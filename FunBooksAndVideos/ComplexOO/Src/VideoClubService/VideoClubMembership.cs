using DDD.Core.Domain;
using DDD.Core.Repository;

namespace VideoClubService
{
    public class VideoClubMembership : Entity<int>
    {
        public VideoClubMembership(int customerId) 
            : base(customerId)
        {
        }

        protected VideoClubMembership()
        {
        }

        public static VideoClubMembership Create(int customerId)
        {
            var newMembership = new VideoClubMembership
            {
                Id = customerId
            };

            return newMembership;
        }
    }
}
