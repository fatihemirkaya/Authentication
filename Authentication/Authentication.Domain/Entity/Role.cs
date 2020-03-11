using Authentication.Common.Entity;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Entity
{
    public class Role : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual string RoleName { get; protected set; }
        public virtual string RoleDescription { get; protected set; }
        public virtual Group Group { get; protected set; }
        public virtual long GroupId { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual ICollection<RoleMenu> RoleMenu { get; protected set; }

        public virtual ICollection<RoleGroup> RoleGroup { get; protected set; }
        public virtual ICollection<RolePermission> RolePermissions { get; protected set; }


        public Role()
        { }

        public Role(string roleName, string roleDesc, Group grp)
        {
            this.RoleName = roleName;
            this.RoleDescription = roleDesc;
            this.Group = grp;
            this.CreationTime = DateTime.Now;
            this.CreatorUserId = 1; //TODO
        }
        public Role RoleUpdate(string roleName, string roleDesc)
        {
            if (!String.IsNullOrWhiteSpace(roleName))
                this.RoleName = roleName;

            if (!String.IsNullOrWhiteSpace(roleDesc))
                this.RoleDescription = roleDesc;


            return this;


        }

    }


}
