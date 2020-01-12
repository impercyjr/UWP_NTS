using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1809E_UWP_DAPI.Models
{

    public class Member
    {
        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
        
    }
    public class LoginToken
    {
        public string token { get; set; }
        public string secretToken { get; set; }

    }
}
