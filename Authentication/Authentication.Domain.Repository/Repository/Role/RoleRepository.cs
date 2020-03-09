using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using Authentication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.Role
{
    public class RoleRepository : BaseRepository<Entity.Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationContext _context) : base(_context)
        {


        }

    }
}
