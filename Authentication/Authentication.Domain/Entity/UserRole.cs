using Authentication.Common.Entity;
using System;

namespace Authentication.Domain.Entity
{
    public class UserRole : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual long UserId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual long RoleId { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
    }


}
