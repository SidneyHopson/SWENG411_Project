using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VA_Patient_Registration_Site.Models
{
    public class Patient
    {
        [ForeignKey("User")]

        [Key]
        public int Pat_id { get; set; }
        public string Pat_fname { get; set; }
        public string Pat_lname { get; set; }
        public DateTime DOB { get; set; }
        public int Doc_id { get; set; }
        public User User { get; set; }
    }
}
