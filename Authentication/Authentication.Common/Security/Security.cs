using Microsoft.AspNetCore.DataProtection;
using System;
using System.Linq;

namespace Authentication.Common.Security
{
    public class Security : ISecurityService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;


        public Security(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        private static Random random = new Random();
        private string GeneratedKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 20)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }
        public string[] Encrypt(string input)
        {
            var key = GeneratedKey();
            var protector = _dataProtectionProvider.CreateProtector(key);
            return new string[] { protector.Protect(input), key };
        }

        public string Decrypt(string input, string salt)
        {
            var protector = _dataProtectionProvider.CreateProtector(salt);
            return protector.Unprotect(input);
        }
    }
}
