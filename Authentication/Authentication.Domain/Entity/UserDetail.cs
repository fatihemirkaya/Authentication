using Authentication.Common.Entity;
using System;

namespace Authentication.Domain.Entity
{
    public class UserDetail : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual long UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual string MobilePhone { get; protected set; }
        public virtual string Phone1 { get; protected set; }
        public virtual string Phone2 { get; protected set; }
        public virtual string Address { get; protected set; }
        public virtual string City { get; protected set; }
        public virtual string Country { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }

        public UserDetail() { }

      
    }


}
