using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Common.Security
{
    public static class HashHelper
    {
        public static string[] GetEncryptedString(string _password)
        {
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<Security>(LockerKey);
            return locker.Encrypt(_password);
        }

        public static string GetDecryptedString(string _hashedPassword, string salt)
        {
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var LockerKey = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<Security>(LockerKey);
            return locker.Decrypt(_hashedPassword, salt);
        }
    }
}
