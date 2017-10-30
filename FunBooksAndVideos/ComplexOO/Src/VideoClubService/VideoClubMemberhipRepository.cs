using DDD.Core.Repository;
using System;
using System.Linq;

namespace VideoClubService
{
    public interface IVideoClubMembershipRepository : IRepository<VideoClubMembership, int>
    { }

    public class VideoClubMemberhipRepository : IVideoClubMembershipRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public VideoClubMembership Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VideoClubMembership> Get()
        {
            throw new NotImplementedException();
        }

        public void Save(VideoClubMembership entity)
        {
            throw new NotImplementedException();
        }
    }

}
