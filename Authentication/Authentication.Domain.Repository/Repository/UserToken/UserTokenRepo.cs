using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Repository
{
    public class UserTokenRepo : BaseRepository<Entity.UserToken>, IUserTokenRepo
    {
        public UserTokenRepo(AuthenticationContext _context) : base(_context)
        {

        }

        public bool DeleteUserToken(Entity.UserToken userToken)
        {
            var removed = false;
            if (userToken != null)
            {
                removed = true;
                base.Delete(userToken);
            }
            return removed;
        }

        public Entity.UserToken GetUserTokenByUserId(long userId)
        {
            return base.Get(x => x.UserId == userId);
        }

        public Task InsertUserToken(Entity.UserToken userToken)
        {
            return base.InsertAsync(userToken);
        }

        public Entity.UserToken GetUserByRefreshToken(string refreshToken)
        {
            var userToken = base.Get(x =>
               x.RefreshToken == refreshToken);

            return userToken;
        }

        public Entity.UserToken GetUserByRefreshToken(string refreshToken, long userId)
        {
            return base.Get(x => x.UserId == userId && x.RefreshToken == refreshToken);
        }
    }
}
