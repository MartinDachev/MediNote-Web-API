using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    public class MedicalNoteService
    {

        MediNoteEntities MedicalNoteContext = new MediNoteEntities();

        public void AddMedicalNote(MedicalNoteDTO newMedicalNoteInfo)
        {
            MedicalNoteContext.spAddMedicalNote(newMedicalNoteInfo.DoctorID, newMedicalNoteInfo.StudentID, newMedicalNoteInfo.InstitutionID,
                newMedicalNoteInfo.MEN, newMedicalNoteInfo.VisitDate, newMedicalNoteInfo.Diagnose, newMedicalNoteInfo.Needs);            
        }

        public MedicalNoteDTO GetMedicalNoteByID(int medicalNoteID)
        {
            var returnedMedicalNote = MedicalNoteContext.medicalNote_table.Find(medicalNoteID);
            MedicalNoteDTO medicalNote = new MedicalNoteDTO();
            medicalNote.InstitutionID = returnedMedicalNote.InstitutionID;
            medicalNote.MEN = returnedMedicalNote.MEN;
            medicalNote.Needs = returnedMedicalNote.Needs;
            medicalNote.StudentID = returnedMedicalNote.StudentID;
            medicalNote.VisitDate = returnedMedicalNote.VisitDate;
            medicalNote.Diagnose = returnedMedicalNote.Diagnose;  
            return medicalNote;
        }

        public MedicalNoteDTO GetMedicalNoteByMEN(string MEN)
        {
            var returnedMedicalNote = MedicalNoteContext.spGetMedicalNoteByMEN(MEN);

            if (returnedMedicalNote == null)
            {
                return null;
            }

            MedicalNoteDTO medicalNote = new MedicalNoteDTO();

            medicalNote = returnedMedicalNote.Select(m => new MedicalNoteDTO
            {
                InstitutionID = m.InstitutionID,
                DoctorID = m.DoctorID,
                StudentID = m.StudentID,
                HealthcareFacilityId = m.HealthcareFacilityId,
                FacilityName = m.FacilityName,
                StudentName = m.StudentName,
                StudentAddress = m.StudentAddress,
                StudentAge = m.StudentAge,
                Needs = m.Needs,
                InstitutionName = m.InstitutionName,
                DoctorName = m.DoctorName,
                DoctorPosition = m.DoctorPosition,
                VisitDate = m.VisitDate,
                Diagnose = m.Diagnose,
                MEN = m.MEN
            }).FirstOrDefault();

            return medicalNote;
        }

        public IEnumerable<MedicalNoteDTO> GetMedicalNotesByStudentNIN(string NIN)
        {
            var medicalNotes = MedicalNoteContext.spGetAllMedicalNotesByNIN(NIN).ToList();
            return medicalNotes.Select(m => new MedicalNoteDTO
            {
                InstitutionID = m.InstitutionID,
                DoctorID = m.DoctorID,
                StudentID = m.StudentID,
                HealthcareFacilityId = m.HealthcareFacilityId,
                FacilityName = m.FacilityName,
                StudentName = m.StudentName,
                StudentAddress = m.StudentAddress,
                StudentAge = m.StudentAge,
                Needs = m.Needs,
                InstitutionName = m.InstitutionName,
                DoctorName = m.DoctorName,
                DoctorPosition = m.DoctorPosition,
                VisitDate = m.VisitDate,
                Diagnose = m.Diagnose,
                MEN = m.MEN
            }).ToList();
        }
    }
}
