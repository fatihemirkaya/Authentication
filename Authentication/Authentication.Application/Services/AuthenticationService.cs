using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUnitOfWork uow;

        public AuthenticationService(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public async Task<bool> InsertUser()
        {
            User usr = new User("burak1", "burakuser", "buraksurname", "aburakbasaran@gmail.com", "22323", "323");
            User usr2 = new User("burak2", "burakuser", "buraksurname", "aburakbasaran@gmail.com", "22323", "323");
            User usr3 = new User("burak3", "burakuser", "buraksurname", "aburakbasaran@gmail.com", "22323", "323");
            User usr4 = new User("burak4", "burakuser", "buraksurname", "aburakbasaran@gmail.com", "22323", "323");

            User usr5 = new User();
         
            await uow.User.InsertAsync(usr);
            await uow.User.InsertAsync(usr2);
            await uow.User.InsertAsync(usr3);
            await uow.User.InsertAsync(usr4);
            await uow.User.InsertAsync(usr5);

            await uow.CompleteAsync();


            return false;
        }
    }
}