using Authentication.Common.Entity;
using System;
using System.Collections.Generic;

namespace Authentication.Domain.Entity
{
    public class User : BaseEntity, ISoftDeleted, IAudit
    {
        public virtual string UserName { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string SurName { get; protected set; }
        public virtual string Email { get; protected set; }
        public string Password { get; protected set; }
        public virtual string PasswordSalt { get; protected set; }
        public virtual long CreatorUserId { get; protected set; }
        public virtual long? ModifierUserId { get; protected set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual DateTime? LastModTime { get; protected set; }

        public virtual UserDetail UserDetail { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual ICollection<UserRole> UserRoles { get; protected set; }

        public User() { }

        public User(string _userName, string _name, string _surName ,string _email, string _password, string _passwordSalt)
        {
            this.UserName = _userName;
            this.Name = _name;
            this.SurName = _surName;
            this.Email = _email;
            this.PasswordSalt = _passwordSalt;
            this.Password = _password;
            this.CreatorUserId = 1;
            this.CreationTime = DateTime.Now;
            this.IsDeleted = false;
            this.Status = StatusType.Available;
        }
    }


}
