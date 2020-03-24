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
        public virtual long CreatorUserId { get;  set; }
        public virtual long ApplicationId { get; protected set; }
        public virtual Application Application { get; protected set; }     
        public virtual DateTime CreationTime { get;  set; }
        public virtual DateTime? LastModTime { get;  set; }
        public virtual long? ModifierUserId { get;  set; }
        public virtual ICollection<RoleGroup> RoleGroups { get; protected set; }



    }

}
