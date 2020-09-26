using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspNetCoreAPI.Models
{
    public class Phone
    {
        public int PhoneId { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public int ContactInfoId { get; set; }
       
        [JsonIgnore]
        public ContactInfo ContactInfo { get; set; }

    }
}
