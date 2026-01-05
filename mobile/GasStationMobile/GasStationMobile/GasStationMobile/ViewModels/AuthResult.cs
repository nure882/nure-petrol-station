using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationMobile.ViewModels
{
    public class AuthResult
    {
        public bool Successed { get; set; }
        public string JwtToken { get; set; }
        public string ErrorString { get; set; }
    }
}
