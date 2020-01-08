using Authentication.Domain.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Uow
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}
