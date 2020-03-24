using Authentication.Common.Entity;
using System;

namespace Authentication.Domain.Entity
{
    public class UserApplication : BaseEntity, ISoftDeleted, IAudit
    {

        public virtual Application Application { get; protected set; }
        public virtual long ApplicationId { get; protected set; }
        public virtual User User { get; protected set; }
        public virtual long UserId { get; protected set; }
        public virtual long CreatorUserId { get;  set; }
        public virtual long? ModifierUserId { get;  set; }      
        public virtual DateTime CreationTime { get;  set; }      
        public virtual DateTime? LastModTime { get;  set; }
        public virtual bool IsDeleted { get; protected set; }


        public UserApplication() { }

        public UserApplication(long _appId, long _userId)
        {
            this.ApplicationId = _appId;
            this.UserId = _userId;
            this.Status = StatusType.Available;
            this.IsDeleted = false;
        }


    }
}
