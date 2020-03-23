using Authentication.Domain.Repository.Base;

namespace Authentication.Domain.Repository.Repository
{
    public interface IUserRoleRepository : IBaseRepository<Entity.UserRole>
    {
        public bool HasPermission(long userId, string actionName);
    }
}
