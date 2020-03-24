using Authentication.Common.Entity;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Entity
{
    public class Application : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual string ApplicationName { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual long CreatorUserId { get;  set; }      
        public virtual DateTime CreationTime { get;  set; }
        public virtual DateTime? LastModTime { get;  set; }
        public virtual long? ModifierUserId { get;  set; }
        public virtual ICollection<Menu> Menu { get; protected set; }
        public virtual ICollection<Permission> Permission { get; protected set; }
        public virtual ICollection<Group> Group { get; protected set; }
        public virtual ICollection<UserApplication> UserApplications { get; protected set; }


        public Application(string _appName, string _desC)
        {
            this.ApplicationName = _appName;
            this.Description = _desC;
            this.IsDeleted = false;
        }
        public Application()
        {

        }



    }
}
