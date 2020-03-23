using Authentication.Domain.Repository.Repository;
using Authentication.Domain.Repository.Repository.Group;
using Authentication.Domain.Repository.Repository.Permission;
using Authentication.Domain.Repository.Repository.RoleGroup;
using Authentication.Domain.Repository.Repository.RolePermission;
using Authentication.Domain.Repository.Repository.UserGroup;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Uow
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IUserTokenRepo UserToken { get; }
        IRoleRepository Role { get; }
        IRolePermissionRepository RolePermission { get; }
        IUserGroupRepository UserGroup { get; }
        IRoleGroupRepository RoleGroup { get; }
        IPermissionRepository Permission { get; }
        IGroupRepository Group { get; }
        IUserApplicationRepository UserApplication { get; }
        IApplicationRepository Application { get; }
        IUserRoleRepository UserRole { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}
