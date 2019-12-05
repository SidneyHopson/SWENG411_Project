using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VA_Patient_Registration_Site.Models
{
    public class DoctorsPatients
    {
        [Key]
        public int Id { get; set; }
        public int Doc_id { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
