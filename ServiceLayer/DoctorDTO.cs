using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class DoctorDTO
    {
        public string  DoctorName { get; set; }
        public string DoctorPosition { get; set; }
        public string DoctorUIN { get; set; }
        public int HealthcareFacilityId { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhoneNumber { get; set; }

    }
}
