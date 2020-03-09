using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.RolePermission
{
    public class RolePermissionRepository : BaseRepository<Entity.RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(AuthenticationContext _context) : base(_context)
        {


        }

    }
}
