using Authentication.Common.Entity;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Entity
{
    public class Group : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual string GroupName { get; protected set; }
        public virtual string GroupDescription { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual ICollection<Role> Roles { get; protected set; }



    }

}
