using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;

namespace Authentication.Domain.Repository.Repository.Group
{
    public class GroupRepository : BaseRepository<Entity.Group>, IGroupRepository
    {
        public GroupRepository(AuthenticationContext _context) : base(_context)
        {


        }




    }
}
