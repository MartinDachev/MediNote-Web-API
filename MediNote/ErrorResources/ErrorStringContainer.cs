using MediNote.ErrorCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediNote.ErrorResources
{
    public static class ErrorStringContainer
    {
        private static Dictionary<ErrorCode, string> errorStrings = new Dictionary<ErrorCode, string>()
        {
            { ErrorCode.DoctorAlreadyExistsWithThisNIN, "Doctor already exists with this NIN" },
            { ErrorCode.StudentAlreadyExistsWithThisNIN, "Student already exists with this NIN" },
            { ErrorCode.StudentNotFoundWithThisNIN, "Student not found with this NIN" },
            { ErrorCode.DoctorNotFoundWithThisNIN, "Doctor not found with this NIN" },
            { ErrorCode.MedicalNoteAlreadyExistsWithThisMEN, "Medical note already exists with this MEN" },
            { ErrorCode.MedicalNoteNotFoundWithThisMEN, "Medical note not found with this MEN" },
            { ErrorCode.DoctorsCanOnlyAddMedicalNotesWithTheirNIN, "Doctors can only add a Medical note with " +
                "their own NIN,\nthey cannot add on behalf of others" },
            { ErrorCode.StudentsCanCheckOnlyMedicalNotesWithTheirNIN, "Students can check only medical notes with their NIN" },
            { ErrorCode.StudentCouldNotBeAddedToRole, "An error occurred while trying to add student to role \"Student\"" },
            { ErrorCode.DoctorCouldNotBeAddedToRole, "An error occurred while trying to add doctor to role \"Doctor\"" },
            { ErrorCode.DoctorsCanOnlyGetTheirInformation, "Doctors can only get their information" },
            { ErrorCode.StudentsCanOnlyGetTheirInformation,"Students can only get their information" }
        };

        public static string GetStringError(ErrorCode errorCode)
        {
            string error = errorStrings[errorCode];

            return error;
        }
    }
}