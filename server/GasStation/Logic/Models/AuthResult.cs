using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class AuthResult
    {
        public bool Successed { get; }
        public string JwtToken { get; }
        public string ErrorString { get; private set; }

        public AuthResult (bool successed)
        {
            Successed = successed;
        }

        public AuthResult (bool successed, string jwtToken)
        {
            Successed = successed;
            JwtToken = jwtToken;
        }

        public void SetErrorString(string str)
        {
            ErrorString = str;
        }
    }
}
