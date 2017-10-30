using System.Collections.Generic;
using System.Linq;

namespace VideoClubService.Tests
{
    public class FakeVideoClubMembershipRepository : IVideoClubMembershipRepository
    {
        private List<VideoClubMembership> _VideoClubMemberships;

        public FakeVideoClubMembershipRepository()
        {
            _VideoClubMemberships = new List<VideoClubMembership>();
        }

        public void Delete(int id)
        {
            var membership = _VideoClubMemberships.SingleOrDefault(m => m.Id == id);
            if (membership != null)
            {
                _VideoClubMemberships.Remove(membership);
            }
        }

        public VideoClubMembership Get(int id)
        {
            return _VideoClubMemberships.SingleOrDefault(m => m.Id == id);
        }

        public IQueryable<VideoClubMembership> Get()
        {
            return _VideoClubMemberships.AsQueryable();
        }

        public void Save(VideoClubMembership entity)
        {
            var membership = _VideoClubMemberships.SingleOrDefault(m => m.Id == entity.Id);

            if (membership == null)
            {
                _VideoClubMemberships.Add(entity);
            }
        }
    }
}
