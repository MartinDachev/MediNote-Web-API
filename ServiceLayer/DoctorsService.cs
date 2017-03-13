using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace ServiceLayer
{
    public class DoctorService
    {
        MediNoteEntities DoctorContext = new MediNoteEntities();

        public void AddDoctor(DoctorDTO newDoctorInfo)
        {
            DoctorContext.spAddNewDoctor(newDoctorInfo.DoctorName,
                newDoctorInfo.DoctorPosition, newDoctorInfo.DoctorUIN,
                newDoctorInfo.HealthcareFacilityId, newDoctorInfo.DoctorEmail,
                newDoctorInfo.DoctorPhoneNumber, newDoctorInfo.DoctorNIN);
        }

        public DoctorDTO GetDoctorByID(int doctorID)
        {
            var returnedDoctor = DoctorContext.doctors_table.Find(doctorID);

            if (returnedDoctor == null)
            {
                return null;
            }

            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.DoctorEmail = returnedDoctor.DoctorEmail;
            doctorDTO.DoctorName = returnedDoctor.DoctorName;
            doctorDTO.DoctorPhoneNumber = returnedDoctor.DoctorPhoneNumber;
            doctorDTO.DoctorPosition = returnedDoctor.DoctorPosition;
            doctorDTO.DoctorUIN = returnedDoctor.DoctorUIN;
            doctorDTO.DoctorNIN = returnedDoctor.DoctorNIN;
            doctorDTO.Id = returnedDoctor.ID;
            doctorDTO.HealthcareFacilityId = returnedDoctor.HealthcareFacilityId;

            var healthCareFacilitiesService = new HealthCareFacilitiesService();
            var facility = healthCareFacilitiesService.GetFacilityByID(returnedDoctor.HealthcareFacilityId);

            doctorDTO.HealthcareFacilityName = facility;
            return doctorDTO;
        }

        public DoctorDTO GetDoctorByNIN(string doctorNIN)
        {
            var returnedDoctor = DoctorContext.spGetDoctorByNIN(doctorNIN).FirstOrDefault();

            if (returnedDoctor == null)
            {
                return null;
            }

            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.DoctorEmail = returnedDoctor.DoctorEmail;
            doctorDTO.DoctorName = returnedDoctor.DoctorName;
            doctorDTO.DoctorPhoneNumber = returnedDoctor.DoctorPhoneNumber;
            doctorDTO.DoctorPosition = returnedDoctor.DoctorPosition;
            doctorDTO.DoctorUIN = returnedDoctor.DoctorUIN;
            doctorDTO.DoctorNIN = returnedDoctor.DoctorNIN;
            doctorDTO.Id = returnedDoctor.ID;
            doctorDTO.HealthcareFacilityId = returnedDoctor.HealthcareFacilityId;

            var healthCareFacilitiesService = new HealthCareFacilitiesService();
            var facility = healthCareFacilitiesService.GetFacilityByID(returnedDoctor.HealthcareFacilityId);

            doctorDTO.HealthcareFacilityName = facility;

            return doctorDTO;
        }

        public void DeleteDoctorByID(int doctorID)
        {
            DoctorContext.spDeleteDoctorByID(doctorID);
            
        }

        public void UpdateDoctorByID(int doctorID, DoctorDTO updateDoctorInfo)
        {

            DoctorContext.spUpdateDoctorByID(doctorID, updateDoctorInfo.DoctorName, updateDoctorInfo.DoctorPosition,
                updateDoctorInfo.DoctorUIN, updateDoctorInfo.HealthcareFacilityId,
                updateDoctorInfo.DoctorEmail, updateDoctorInfo.DoctorPhoneNumber, updateDoctorInfo.DoctorNIN);
        }

    }
}
