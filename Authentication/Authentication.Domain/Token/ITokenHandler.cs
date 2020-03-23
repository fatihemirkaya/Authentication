using Authentication.Domain.Entity;

namespace Authentication.Domain.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
    }
}
