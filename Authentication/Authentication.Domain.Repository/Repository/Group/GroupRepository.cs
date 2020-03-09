using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.Group
{
    public class GroupRepository : BaseRepository<Entity.Group>, IGroupRepository
    {
        public GroupRepository(AuthenticationContext _context) : base(_context)
        {


        }




    }
}
