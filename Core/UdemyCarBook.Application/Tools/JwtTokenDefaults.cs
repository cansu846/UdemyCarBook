using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudince = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "this_super_secret_key_0123456789";
        public const int Expire = 3;
    }
}
