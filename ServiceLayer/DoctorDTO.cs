using ServiceLayer.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        [Required]
        public string  DoctorName { get; set; }
        
        [Required]
        public string DoctorPosition { get; set; }

        [Required]
        public string DoctorUIN { get; set; }

        [Required]
        public string HealthcareFacilityName { get; set; }

        public int HealthcareFacilityId { get; set; }
       
        [Required]
        public string DoctorEmail { get; set; }

        [Required]
        public string DoctorPhoneNumber { get; set; }

        [Required]
        [NIN]
        public string DoctorNIN { get; set; }
    }
}
