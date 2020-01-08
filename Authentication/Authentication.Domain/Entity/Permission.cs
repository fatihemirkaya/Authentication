using Authentication.Common.Entity;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Entity
{
    public class Permission : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual string PermissionName { get; protected set; }
        public virtual string PermissionDescription { get; protected set; }
        public virtual string ActionName { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual ICollection<RolePermission> RolePermission { get; protected set; }
    }


}
