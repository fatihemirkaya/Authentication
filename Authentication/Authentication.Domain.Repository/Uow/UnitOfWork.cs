using Authentication.Domain.Repository.Repository;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthenticationContext _dbContext;
        private IUserRepository _user;

        public UnitOfWork(AuthenticationContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IUserRepository User
        {
            get
            {
                if (this._user == null)
                {
                    this._user = new UserRepository(_dbContext);
                }
                return this._user;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
