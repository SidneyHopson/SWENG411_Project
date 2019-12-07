using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VA_Patient_Registration_Site.Models
{
    public class Doctor
    {
        [ForeignKey("User")]

        [Key]
        public int Doc_id { get; set; }
        public string Doc_fname { get; set; }
        public string Doc_lname { get; set; }
        public User User { get; set; }

        public int PassCode { get; set; }

    }
}
