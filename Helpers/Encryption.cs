﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Encryption
    {
        public static string GenerateSalt()
        {
            var saltBytes = new byte[255];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public static string GenerateHash(string inputPassword, string salt)
        {
            HMACSHA256 algorithm = new HMACSHA256(Encoding.UTF8.GetBytes(salt));
            var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputPassword + salt));
            return Encoding.UTF8.GetString(hash);
        }
    }
}