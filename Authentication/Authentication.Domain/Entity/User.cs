using Authentication.Common.Entity;
using Authentication.Common.Enum;
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
        public virtual long CreatorUserId { get;  set; }
        public virtual long? ModifierUserId { get;  set; }
        public UserType UserType { get; protected set; }      
        public virtual DateTime CreationTime { get;  set; }
        public virtual DateTime? LastModTime { get;  set; }
        public virtual UserDetail UserDetail { get; protected set; }
        public virtual UserToken UserToken { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual ICollection<UserRole> UserRoles { get; protected set; }
        public virtual ICollection<UserApplication> UserApplications { get; protected set; }
        public User() { }
        public User(string _userName, string _name, string _surName, string _email, string _password, string _passwordSalt, UserType _usertype = UserType.User)
        {
            this.UserName = _userName;
            this.Name = _name;
            this.SurName = _surName;
            this.Email = _email;
            this.PasswordSalt = _passwordSalt;
            this.Password = _password;
            this.UserType = _usertype;
            this.IsDeleted = false;
            this.Status = StatusType.Available;
        }

        public User UserUpdate(string _name, string _surname, string _email)
        {
            if (!String.IsNullOrWhiteSpace(_name))
                this.Name = _name;

            if (!String.IsNullOrWhiteSpace(SurName))
                this.SurName = _surname;

            if (!String.IsNullOrWhiteSpace(Email))   //TODO Email Doğrulama
                this.Email = _email;

            return this;


        }
    }


}
