using Authentication.Common.Entity;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Entity
{
    public class Menu : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual string MenuName { get; protected set; }
        public virtual string MenuDescription { get; protected set; }
        public virtual string MenuLink { get; protected set; }
        public virtual string MenuCode { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; protected set; }

    }
    }
