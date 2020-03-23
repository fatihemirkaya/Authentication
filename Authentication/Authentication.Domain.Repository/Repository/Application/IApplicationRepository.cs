using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Base;

namespace Authentication.Domain.Repository.Repository.Group
{
    public interface IApplicationRepository : IBaseRepository<Entity.Application>
    {
        Application GetApplicationByClientCode(long appId);
    }
}
