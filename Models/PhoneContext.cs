using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAPI.Models
{
    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
        {

        }
    }
}
