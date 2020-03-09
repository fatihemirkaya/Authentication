using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.UserGroup
{
    public class UserGroupRepository : BaseRepository<Entity.UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(AuthenticationContext _context) : base(_context)
        {


        }
    }
}

