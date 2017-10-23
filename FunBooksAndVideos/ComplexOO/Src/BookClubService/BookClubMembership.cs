using DDD.Core.Domain;
using MediatR;

namespace BookClubService
{
    public class BookClubMembership : Entity<int>
    {
        public BookClubMembership(int customerId) 
            : base(customerId)
        {
        }

        protected BookClubMembership()
        {
        }

        public static BookClubMembership Create(int customerId)
        {
            var newMembership = new BookClubMembership
            {
                Id = customerId
            };

            return newMembership;
        }
    }
}
