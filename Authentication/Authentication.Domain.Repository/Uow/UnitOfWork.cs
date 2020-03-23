using Authentication.Domain.Repository.Repository;
using Authentication.Domain.Repository.Repository.Group;
using Authentication.Domain.Repository.Repository.Permission;
using Authentication.Domain.Repository.Repository.Role;
using Authentication.Domain.Repository.Repository.RoleGroup;
using Authentication.Domain.Repository.Repository.RolePermission;
using Authentication.Domain.Repository.Repository.UserGroup;
using Authentication.Persistence.Context;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthenticationContext _dbContext;
        private IUserRepository _user;
        private IRoleRepository _role;
        private IGroupRepository _group;
        private IUserGroupRepository _userGroup;
        private IPermissionRepository _permission;
        private IRolePermissionRepository _rolePermission;
        private IRoleGroupRepository _roleGroup;
        private IUserTokenRepo _userToken;
        private IUserRoleRepository _userRole;
        private IUserApplicationRepository _userApplication;
        private IApplicationRepository _application;
        public UnitOfWork(AuthenticationContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IUserRepository User
        {
            get
            {
                if (this._user == null)
                {
                    this._user = new UserRepository(_dbContext);
                }
                return this._user;
            }
        }
        public IUserApplicationRepository UserApplication
        {
            get
            {
                if (this._userApplication == null)
                {
                    this._userApplication = new UserApplicationRepository(_dbContext);
                }
                return this._userApplication;
            }
        }
        public IApplicationRepository Application
        {
            get
            {
                if (this._application == null)
                {
                    this._application = new ApplicationRepository(_dbContext);
                }
                return this._application;
            }
        }
        public IRoleRepository Role
        {
            get
            {
                if (this._role == null)
                {
                    this._role = new RoleRepository(_dbContext);
                }
                return this._role;
            }
        }
        public IUserRoleRepository UserRole
        {
            get
            {
                if (this._userRole == null)
                {
                    this._userRole = new UserRoleRepository(_dbContext);
                }
                return this._userRole;
            }
        }
        public IGroupRepository Group
        {
            get
            {
                if (this._group == null)
                {
                    this._group = new GroupRepository(_dbContext);
                }
                return this._group;
            }
        }
        public IUserGroupRepository UserGroup
        {
            get
            {
                if (this._userGroup == null)
                {
                    this._userGroup = new UserGroupRepository(_dbContext);
                }
                return this._userGroup;
            }
        }
        public IRolePermissionRepository RolePermission
        {
            get
            {
                if (this._rolePermission == null)
                {
                    this._rolePermission = new RolePermissionRepository(_dbContext);
                }
                return this._rolePermission;
            }
        }
        public IRoleGroupRepository RoleGroup
        {
            get
            {
                if (this._roleGroup == null)
                {
                    this._roleGroup = new RoleGroupRepository(_dbContext);
                }
                return this._roleGroup;
            }
        }
        public IPermissionRepository Permission
        {
            get
            {
                if (this._permission == null)
                {
                    this._permission = new PermissionRepository(_dbContext);
                }
                return this._permission;
            }
        }
        public IUserTokenRepo UserToken
        {
            get
            {
                if (this._userToken == null)
                {
                    this._userToken = new UserTokenRepo(_dbContext);
                }
                return this._userToken;
            }
        }
        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
