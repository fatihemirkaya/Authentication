using Authentication.Common.Constants;
using Authentication.Common.Entity;
using Authentication.Common.Exceptions;
using Authentication.Common.Security;
using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Base;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        AuthenticationContext context;
        public UserRepository(AuthenticationContext _context) : base(_context)
        {
            this.context = _context;
        }

        public List<User> GetUsers(long userid, string username, string name, string surname, string email)
        {
            if (userid <= 1 && String.IsNullOrWhiteSpace(username) && String.IsNullOrWhiteSpace(name) && String.IsNullOrWhiteSpace(surname) && String.IsNullOrWhiteSpace(email))
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }

            IQueryable<User> query = context.User.Where(x => 1 == 1);

            if (userid > 0)
            {
                query = context.User.Where(x => x.Id == userid).AsQueryable();
            }

            if (!String.IsNullOrWhiteSpace(username))
            {
                query = context.User.Where(x => x.UserName.Contains(username)).AsQueryable();
            }


            if (!String.IsNullOrWhiteSpace(name))
            {
                query = context.User.Where(x => x.Name.Contains(name)).AsQueryable();
            }


            if (!String.IsNullOrWhiteSpace(surname))
            {
                query = context.User.Where(x => x.SurName.Contains(surname)).AsQueryable();
            }

            if (!String.IsNullOrWhiteSpace(email))
            {
                query = context.User.Where(x => x.Email.Contains(email)).AsQueryable();
            }

            return query.ToList();
        }

        public async Task<User> ValidateUser(string username, string password = "")
        {

            var user = await base.GetAsync((x =>
               x.UserName == username
            && x.IsDeleted == false
            && x.Status == StatusType.Available));

            if (user == null)
            {
                throw new BusinessException(ResponseCode.UserNotFound);
            }

            if (HashHelper.GetDecryptedString(user.Password, user.PasswordSalt) != password)
                throw new BusinessException(ResponseCode.UserIsNotActive);

            return user;
        }
    }
}
