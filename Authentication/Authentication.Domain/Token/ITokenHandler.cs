using Authentication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Token
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
    }
}
