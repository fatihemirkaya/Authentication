using Authentication.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Repository
{
    public interface IUserTokenRepo : IBaseRepository<Entity.UserToken>
    {
        public bool DeleteUserToken(Entity.UserToken userToken);
        public Entity.UserToken GetUserTokenByUserId(long userId);
        public Task InsertUserToken(Entity.UserToken userToken);
        public Entity.UserToken GetUserByRefreshToken(string refreshToken);

        public Entity.UserToken GetUserByRefreshToken(string refreshToken, long userId);

    }
}
