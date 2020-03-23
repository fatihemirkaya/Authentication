using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Repository.Repository.Group
{
    public interface IApplicationRepository : IBaseRepository<Entity.Application>
    {
        Application GetApplicationByClientCode(long appId);
    }
}
