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

        public DbSet<VA_Patient_Registration_Site.Models.DoctorsPatients> DoctorsPatients { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.Allergy> Allergy { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.MedicalCondition> MedicalCondition { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.Medication> Medication { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.ShotRecord> ShotRecord { get; set; }

        public DbSet<VA_Patient_Registration_Site.Models.MedicalRecord> MedicalRecord { get; set; }
    }
}
