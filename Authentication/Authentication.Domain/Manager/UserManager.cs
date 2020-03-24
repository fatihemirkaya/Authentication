using Authentication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain.Manager
{
    public static class UserManager 
    {
        public static long ActiveUserId { get; set; }
        public static string ActiveUserName { get; set; }

        public static bool IsLoggin()
        {

            return !string.IsNullOrWhiteSpace(ActiveUserName)? true : false;

          
        }



    }
}
