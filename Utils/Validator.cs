using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T1809E_UWP_DAPI.Utils
{
    class Validator
    {
        private string EmailRule = "^[a-z][a-z0-9_.]{5,32}@[a-z0-9]{2,}(.[a-z0-9]{2,4}){1,2}$";
        private string PhoneRule = "^[+][8][4](09|03|01[2|6|8|9])+([0-9]{8})$";
        public bool IsNotNullAndNotEmpty(string str)
        {
            return str!=null && !str.Equals("");
        }

        public bool IsPasswordMatch(string password1, string password2)
        {
            return password1.Equals(password2);
        }

        public bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, PhoneRule);
        }

        public bool IsEmail(string email)
        {
            return Regex.IsMatch(email, EmailRule);
        }
    }
}
