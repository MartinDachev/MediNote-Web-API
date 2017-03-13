using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.ValidationAttributes;

namespace ServiceLayer
{
    public class MedicalNoteBasicDTO
    {
        public MedicalNoteBasicDTO()
        {
        }

        [Required]
        [NIN]
        public string DoctorNIN { get; set; }

        [Required]
        public string StudentNIN { get; set; }

        [Required]
        public string Needs { get; set; }

        [Required]
        public string InstitutionName { get; set; }

        public DateTime VisitDate { get; set; }

        [Required]
        public string Diagnose { get; set; }

        [Required]
        public string MEN { get; set; }
    }
}
