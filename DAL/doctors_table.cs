//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class doctors_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doctors_table()
        {
            this.medicalNote_table = new HashSet<medicalNote_table>();
        }
    
        public int ID { get; set; }
        public string DoctorName { get; set; }
        public string DoctorPosition { get; set; }
        public string DoctorUIN { get; set; }
        public int HealthcareFacilityId { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhoneNumber { get; set; }
    
        public virtual healthcareFacilities_table healthcareFacilities_table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medicalNote_table> medicalNote_table { get; set; }
    }
}