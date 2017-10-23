using System;
using System.Linq;
using DDD.Core.Repository;

namespace BookClubService
{
    public interface IBookClubMembershipRepository : IRepository<BookClubMembership, int>
    {
    }

    public class BookClubMembershipRepository : IBookClubMembershipRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BookClubMembership Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BookClubMembership> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(BookClubMembership entity)
        {
            throw new NotImplementedException();
        }
    }
}
