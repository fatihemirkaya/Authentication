using Authentication.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Entity
{
    public class RoleGroup : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual long RoleID { get; protected set; }
        public virtual Role Role { get; set; }
        public virtual long GroupID { get; protected set; }
        public virtual Group Group { get; set; }

        public RoleGroup()
        {

        }
        public RoleGroup(Role Role, Group Group)
        {
            this.Role = Role;
            this.Group = Group;
            this.CreationTime = DateTime.Now;
            this.CreatorUserId = 1;//TODO
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