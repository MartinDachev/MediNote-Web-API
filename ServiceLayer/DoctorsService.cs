using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace ServiceLayer
{
    class DoctorsService
    {
        MediNoteEntities DoctorContext = new MediNoteEntities();

        public void AddDoctor(DoctorDTO newDoctorInfo)
        {
            DoctorContext.spAddNewDoctor(newDoctorInfo.DoctorName,
                newDoctorInfo.DoctorPosition, newDoctorInfo.DoctorUIN,
                newDoctorInfo.HealthcareFacilityId, newDoctorInfo.DoctorEmail,
                newDoctorInfo.DoctorPhoneNumber);
        }

        public DoctorDTO GetDoctorByID(int doctorID)
        {
            var returnedDoctor = DoctorContext.doctors_table.Find(doctorID);
            DoctorDTO obJDto = new DoctorDTO();
            obJDto.DoctorEmail = returnedDoctor.DoctorEmail;
            obJDto.DoctorName = returnedDoctor.DoctorName;
            obJDto.DoctorPhoneNumber = returnedDoctor.DoctorPhoneNumber;
            obJDto.DoctorPosition = returnedDoctor.DoctorPosition;
            obJDto.DoctorUIN = returnedDoctor.DoctorUIN;

            return obJDto;
        }

        public void DeleteDoctorByID(int doctorID)
        {
            DoctorContext.spDeleteDoctorByID(doctorID);
            
        }

        public void UpdateDoctorByID(int doctorID, DoctorDTO updateDoctorInfo)
        {

            DoctorContext.spUpdateDoctorByID(doctorID, updateDoctorInfo.DoctorName, updateDoctorInfo.DoctorPosition,
                updateDoctorInfo.DoctorUIN, updateDoctorInfo.HealthcareFacilityId,
                updateDoctorInfo.DoctorEmail, updateDoctorInfo.DoctorPhoneNumber);
        }

    }
}
