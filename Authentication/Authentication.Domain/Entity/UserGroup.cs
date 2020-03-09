using Authentication.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Entity
{
    public class UserGroup : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual long CreatorUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }

        public virtual long? ModifierUserId { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual long UserID { get; protected set; }
        public virtual User User { get; set; }
        public virtual long GroupId { get; protected set; }
        public virtual Group Group { get; set; }
        public virtual string Description { get; protected set; }

        public virtual DateTime? LastModTime { get; protected set; }

        public UserGroup()
        {

        }
        public UserGroup(long UserID,long GroupId, string Description, DateTime? LastModTime)
        {
            this.UserID = UserID;
            this.GroupId = GroupId;
            this.Description = Description;
            this.LastModTime = LastModTime;
            this.CreationTime = DateTime.Now;
            this.CreatorUserId = 1;//TODO
        }
    }
}
