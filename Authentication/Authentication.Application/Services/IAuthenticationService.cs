using Authentication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Services
{
    public interface IAuthenticationService
    {
        public  Task<bool> InsertUser();
            
    }
}
