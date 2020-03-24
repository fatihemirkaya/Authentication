using Authentication.Common.Entity;
using System;

namespace Authentication.Domain.Entity
{
    public class RolePermission : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual long PermissionId { get; protected set; }
        public virtual Permission Permission { get; protected set; }
        public virtual long RoleId { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual long CreatorUserId { get;  set; }     
        public virtual DateTime CreationTime { get;  set; }
        public virtual DateTime? LastModTime { get;  set; }
        public virtual long? ModifierUserId { get;  set; }
        public virtual bool IsDeleted { get; protected set; }

        public RolePermission(Role role, Permission permission)
        {
            Role = role;
            Permission = permission;
        }

        public RolePermission()
        {

        }
        public RolePermission RolePermissionUpdate(Role role, Permission permission)
        {
            if (role != null)
                this.Role = role;

            if (permission != null)
                this.Permission = permission;


            return this;


        }

    }


}
