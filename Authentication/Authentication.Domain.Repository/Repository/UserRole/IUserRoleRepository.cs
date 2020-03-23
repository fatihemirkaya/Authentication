using Authentication.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository
{
    public interface IUserRoleRepository : IBaseRepository<Entity.UserRole>
    {
        public bool HasPermission(long userId, string actionName);
    }
}
