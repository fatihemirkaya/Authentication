using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;

namespace Authentication.Domain.Repository.Repository.RolePermission
{
    public class RolePermissionRepository : BaseRepository<Entity.RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(AuthenticationContext _context) : base(_context)
        {


        }

    }
}
