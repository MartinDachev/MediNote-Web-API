using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediNote.ErrorCodes
{
    public enum ErrorCode
    {
        StudentAlreadyExistsWithThisNIN = 19002,
        StudentNotFoundWithThisNIN = 19001,
        StudentsCanCheckOnlyMedicalNotesWithTheirNIN = 19003,
        StudentCouldNotBeAddedToRole = 19004,
        StudentsCanOnlyGetTheirInformation = 19005,
        DoctorNotFoundWithThisNIN = 18001,
        DoctorAlreadyExistsWithThisNIN = 18002,
        DoctorsCanOnlyAddMedicalNotesWithTheirNIN = 18003,
        DoctorCouldNotBeAddedToRole = 18004,
        DoctorsCanOnlyGetTheirInformation = 18005,
        MedicalNoteAlreadyExistsWithThisMEN = 17002,
        MedicalNoteNotFoundWithThisMEN = 17001,
        AccountAlreadyExistsWithThisNIN = 20002,
    }
}