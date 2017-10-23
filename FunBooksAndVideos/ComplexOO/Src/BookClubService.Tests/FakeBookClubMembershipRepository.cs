using System.Collections.Generic;
using System.Linq;

namespace BookClubService.Tests
{
    public class FakeBookClubMembershipRepository : IBookClubMembershipRepository
    {
        private List<BookClubMembership> _BookClubMemberships;

        public FakeBookClubMembershipRepository()
        {
            _BookClubMemberships = new List<BookClubMembership>();
        }

        public void Delete(int id)
        {
            var membership = _BookClubMemberships.SingleOrDefault(m => m.Id == id);
            if (membership != null)
            {
                _BookClubMemberships.Remove(membership);
            }
        }

        public BookClubMembership Get(int id)
        {
            return _BookClubMemberships.SingleOrDefault(m => m.Id == id);
        }

        public IQueryable<BookClubMembership> Get()
        {
            return _BookClubMemberships.AsQueryable();
        }

        public void Save(BookClubMembership entity)
        {
            var membership = _BookClubMemberships.SingleOrDefault(m => m.Id == entity.Id);

            if (membership == null)
            {
                _BookClubMemberships.Add(entity);
            }
        }
    }
}
