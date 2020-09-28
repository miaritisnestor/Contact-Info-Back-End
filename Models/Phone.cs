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

        [Required(ErrorMessage = "Mobile Phone is required")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Home Phone is required")]
        public string HomePhone { get; set; }

        [Required(ErrorMessage = "Work Phone is required")]
        public string WorkPhone { get; set; }

        public int ContactInfoId { get; set; }
       
        [JsonIgnore]
        public ContactInfo ContactInfo { get; set; }

    }
}
