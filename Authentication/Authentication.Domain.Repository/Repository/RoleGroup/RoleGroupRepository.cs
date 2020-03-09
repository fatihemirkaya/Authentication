using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.RoleGroup
{
    public class RoleGroupRepository : BaseRepository<Entity.RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository(AuthenticationContext _context) : base(_context)
        {


        }
    }
}
