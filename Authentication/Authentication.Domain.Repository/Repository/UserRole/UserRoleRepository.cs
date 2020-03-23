using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System.Linq;

namespace Authentication.Domain.Repository.Repository.Role
{
    public class UserRoleRepository : BaseRepository<Entity.UserRole>, IUserRoleRepository
    {
        private readonly AuthenticationContext _dbcontext;
        public UserRoleRepository(AuthenticationContext _context) : base(_context)
        {
            this._dbcontext = _context;
        }

        public bool HasPermission(long userId, string actionName)
        {
            bool result = false;
            var userRole = base.GetInclude(x => x.UserId == userId, "Role");

            if (userRole == null || userRole.Role == null)
            {
                return result;
            }

            var rolePermission = _dbcontext.RolePermission.Where(x => x.RoleId == userRole.RoleId);

            if (rolePermission == null)
            {
                return result;
            }

            var permissions = _dbcontext.Permission.Where(x => x.Status == Common.Entity.StatusType.Available);



            foreach (var rp in rolePermission)
            {
                var permission = permissions.FirstOrDefault(x => x.Id == rp.PermissionId && x.ActionName == actionName);
                if (permission != null)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

    }
}
