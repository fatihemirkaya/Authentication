using Authentication.Common.Enum;
using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public List<User> GetUsers(long userid, string username, string name, string surname, string email);

        public Task<User> ValidateUser(string username = "", string password = "", UserType userType = UserType.User, long appId = 0);
    }
}
