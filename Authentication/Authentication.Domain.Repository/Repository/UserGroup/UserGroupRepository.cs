using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;

namespace Authentication.Domain.Repository.Repository.UserGroup
{
    public class UserGroupRepository : BaseRepository<Entity.UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(AuthenticationContext _context) : base(_context)
        {


        }
    }
}

