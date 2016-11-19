using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    class MedicalNoteService
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
            MedicalNoteDTO objDto = new MedicalNoteDTO();
            objDto.InstitutionID = returnedMedicalNote.InstitutionID;
            objDto.MEN = returnedMedicalNote.MEN;
            objDto.Needs = returnedMedicalNote.Needs;
            objDto.StudentID = returnedMedicalNote.StudentID;
            objDto.VisitDate = returnedMedicalNote.VisitDate;    
            return objDto;
        }
    }
}
