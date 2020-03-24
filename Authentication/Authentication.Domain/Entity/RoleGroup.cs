using Authentication.Common.Entity;
using System;

namespace Authentication.Domain.Entity
{
    public class RoleGroup : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual long CreatorUserId { get;  set; }
        public virtual DateTime CreationTime { get;  set; }      
        public virtual DateTime? LastModTime { get;  set; }
        public virtual long? ModifierUserId { get;  set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual long RoleId { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual long GroupId { get; protected set; }
        public virtual Group Group { get; protected set; }

        public RoleGroup()
        {

        }
        public RoleGroup(Role Role, Group Group)
        {
            this.Role = Role;
            this.Group = Group;
        }
        public RoleGroup RoleGroupUpdate(Role Role, Group Group)
        {
            if (Role != null)
                this.Role = Role;

            if (Group != null)
                this.Group = Group;


            return this;


        }
    }
}