using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class MedicalNoteDTO
    {
        public int DoctorID { get; set; }
        public int StudentID { get; set; }
        public int InstitutionID { get; set; }
        public string MEN { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnose { get; set; }
        public string Needs { get; set; }
    }
}
