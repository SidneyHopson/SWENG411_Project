using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VA_Patient_Registration_Site.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }
        public List<MedicalCondition> MedicalConditions { get; set; }
        public List<Allergy> Allergies { get; set; }
        public List<ShotRecord> ShotRecords { get; set; }
        public List<Medication> Medications { get; set; }
    }
}
