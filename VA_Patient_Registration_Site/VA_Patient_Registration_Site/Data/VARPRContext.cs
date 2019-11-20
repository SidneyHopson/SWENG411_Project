using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VA_Patient_Registration_Site.Models;

namespace VA_Patient_Registration_Site.Models
{
    public class VARPRContext : DbContext
    {
        public VARPRContext (DbContextOptions<VARPRContext> options)
            : base(options)
        {
        }

        public DbSet<VA_Patient_Registration_Site.Models.User> User { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.Patient> Patient { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.Doctor> Doctor { get; set; }
    }
}
