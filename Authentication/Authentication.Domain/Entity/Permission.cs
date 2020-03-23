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
        public virtual long ApplicationId { get; protected set; }
        public virtual Application Application { get; protected set; }
        public virtual ICollection<RolePermission> RolePermission { get; protected set; }


        public Permission()
        { }

        public Permission(string permissionName, string permissionDesc, string actionName,long appId)
        {
            this.PermissionName = permissionName;
            this.PermissionDescription = permissionDesc;
            this.ActionName = actionName;
            this.CreationTime = DateTime.Now;
            this.ApplicationId = appId;
            this.CreatorUserId = 1; //TODO
        }
        public Permission PermissionUpdate(string PermissionName, string PermissionDesc, string ActionName)
        {
            if (!String.IsNullOrWhiteSpace(PermissionName))
                this.PermissionName = PermissionName;

            if (!String.IsNullOrWhiteSpace(PermissionDesc))
                this.PermissionDescription = PermissionDesc;

            if (!String.IsNullOrWhiteSpace(ActionName))   //TODO Email Doğrulama
                this.ActionName = ActionName;

            return this;


        }
    }


}
