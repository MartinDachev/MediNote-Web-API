using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MedicalNoteDTO
    {
        public int Id { get; set; }

        public int DoctorID { get; set; }

        public int StudentID { get; set; }

        public int InstitutionID { get; set; }

        public int HealthcareFacilityId { get; set; }

        public string FacilityName { get; set; }

        public string StudentName { get; set; }

        public string StudentAddress { get; set; }

        public int StudentAge { get; set; }

        public string Needs { get; set; }

        public string InstitutionName { get; set; }

        public string DoctorName { get; set; }

        public string DoctorPosition { get; set; }

        public DateTime VisitDate { get; set; }

        public string Diagnose { get; set; }

        public string MEN { get; set; }
    }
}
