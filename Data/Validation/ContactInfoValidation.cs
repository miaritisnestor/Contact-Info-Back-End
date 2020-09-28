using AspNetCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAPI.Data.Validation
{
    public class ContactInfoValidation
    {

        public ContactInfoValidation()
        {

        }

        public bool isMobilePhoneValid(string mobilePhone)
        {
            if (mobilePhone.Length < 5)
            {
                throw new ArgumentOutOfRangeException("mobile phone can not be less than 5 digits!");
            }
            else
            {
                return true;
            }
            
        }

    }
}
