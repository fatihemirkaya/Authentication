using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;

namespace Authentication.Domain.Repository.Repository.RoleGroup
{
    public class RoleGroupRepository : BaseRepository<Entity.RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(AuthenticationContext _context) : base(_context)
        {


        }
    }
}
