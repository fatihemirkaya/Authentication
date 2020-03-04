using Authentication.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Entity
{
    public class UserToken : BaseEntity
    {
        public virtual long UserId { get; protected set; }
        public User User { get; protected set; }
        public string RefreshToken { get; protected set; }
        public DateTime ExpirationDate { get; protected set; }
        public UserToken() { }

        public UserToken(long _UserId, string _RefreshToken, DateTime _ExpirationDate)
        {
            this.UserId = _UserId;
            this.RefreshToken = _RefreshToken;
            this.ExpirationDate = _ExpirationDate;
        }

    }
}
