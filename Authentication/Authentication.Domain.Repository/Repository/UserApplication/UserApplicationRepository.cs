using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;

namespace Authentication.Domain.Repository.Repository.Group
{
    public class UserApplicationRepository : BaseRepository<Entity.UserApplication>, IUserApplicationRepository
    {
        public UserApplicationRepository(AuthenticationContext _context) : base(_context)
        {


        }




    }
}
