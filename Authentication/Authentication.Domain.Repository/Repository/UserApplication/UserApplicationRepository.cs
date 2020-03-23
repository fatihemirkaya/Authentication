using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.Group
{
    public class UserApplicationRepository : BaseRepository<Entity.UserApplication>, IUserApplicationRepository
    {
        public UserApplicationRepository(AuthenticationContext _context) : base(_context)
        {


        }




    }
}
