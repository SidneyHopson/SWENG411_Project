using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VA_Patient_Registration_Site.Models
{
    public class MedicalCondition
    {
        [Key]
        public int Id { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string Notes { get; set; }
    }
}
