using Authentication.Common.Entity;
using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;

namespace Authentication.Domain.Repository.Repository.Group
{
    public class ApplicationRepository : BaseRepository<Entity.Application>, IApplicationRepository
    {
        public ApplicationRepository(AuthenticationContext _context) : base(_context)
        {


        }

        public Application GetApplicationByClientCode(long appId)
        {
            return base.Get(x =>
               x.Id == appId
            && x.IsDeleted == false
            && x.Status == StatusType.Available);
        }


    }
}
