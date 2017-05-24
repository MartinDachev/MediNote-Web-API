using MediNote.ErrorCodes;
using MediNote.Errors;
using MediNote.Filters;
using ServiceLayer;
using System;
using System.Web.Http;

namespace MediNote.WebApiControllers
{
    [RoutePrefix("api/medicalnotes")]
    public class MedicalNotesController : ApiController
    {
        MedicalNoteService medicalNoteService = new MedicalNoteService();
        
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Student")]
        [Route("{men:length(6)}")]
        public IHttpActionResult GetMedicalNote(string men)
        {
            var medicalNote = medicalNoteService.GetMedicalNoteByMEN(men);

            if (medicalNote == null)
            {
                return new BadRequestWithHttpError(Request, ErrorCode.MedicalNoteNotFoundWithThisMEN);
            }

            if (User.IsInRole("Student"))
            {
                var studentService = new StudentService();
                var student = studentService.GetStudentByID(medicalNote.StudentID);

                if (User.Identity.Name != student.StudentNIN)
                {
                    return new BadRequestWithHttpError(Request, ErrorCode.MedicalNoteNotFoundWithThisMEN);
                }
            }

            if (User.IsInRole("Doctor"))
            {
                var doctorService = new DoctorService();
                var doctor = doctorService.GetDoctorByID(medicalNote.DoctorID);

                if (User.Identity.Name != doctor.DoctorNIN)
                {
                    return new BadRequestWithHttpError(Request, ErrorCode.MedicalNoteNotFoundWithThisMEN);
                }
            }

            return Ok(medicalNote);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Student")]
        [Route("getall/{studentNIN:length(10)}")]
        public IHttpActionResult GetAllMedicalNotes(string studentNIN)
        {
            if (User.Identity.Name != studentNIN && User.IsInRole("Student"))
            {
                return new UnauthorizedWithHttpError(Request, ErrorCode.StudentsCanCheckOnlyMedicalNotesWithTheirNIN);
            }

            var medicalNotes = medicalNoteService.GetMedicalNotesByStudentNIN(studentNIN);
            
            return Ok(medicalNotes);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        [ValidateModel]
        [Route("")]
        public IHttpActionResult AddMedicalNote([FromBody] MedicalNoteBasicDTO basicMedicalNoteInfo)
        {
            if (User.Identity.Name != basicMedicalNoteInfo.DoctorNIN && !User.IsInRole("Admin"))
            {
                return new UnauthorizedWithHttpError(Request, ErrorCode.DoctorsCanOnlyAddMedicalNotesWithTheirNIN);
            }

            var medNoteWithSameMEN = medicalNoteService.GetMedicalNoteByMEN(basicMedicalNoteInfo.MEN);

            if (medNoteWithSameMEN != null)
            {
                return new BadRequestWithHttpError(Request, ErrorCode.MedicalNoteAlreadyExistsWithThisMEN);
            }

            var doctorsService = new DoctorService();
            var doctor = doctorsService.GetDoctorByNIN(basicMedicalNoteInfo.DoctorNIN);

            if (doctor == null)
            {
                return new BadRequestWithHttpError(Request, ErrorCode.DoctorNotFoundWithThisNIN);
            }

            var studentService = new StudentService();
            var student = studentService.GetStudentByNIN(basicMedicalNoteInfo.StudentNIN);

            if (student == null)
            {
                return new BadRequestWithHttpError(Request, ErrorCode.StudentNotFoundWithThisNIN);
            }

            var institutionService = new InstitutionService();
            var institution = institutionService.GetInstitutionByName(basicMedicalNoteInfo.InstitutionName);

            if (institution == null)
            {
                institutionService.AddInstitution(basicMedicalNoteInfo.InstitutionName);
            }

            institution = institutionService.GetInstitutionByName(basicMedicalNoteInfo.InstitutionName);

            if (institution == null)
            {
                return InternalServerError();
            }

            var medicalNoteDTO = new MedicalNoteDTO()
            {
                DoctorID = doctor.Id,
                StudentID = student.Id,
                InstitutionID = institution.Id,
                Needs = basicMedicalNoteInfo.Needs,
                MEN = basicMedicalNoteInfo.MEN,
                // TODO : Change to custom date
                VisitDate = DateTime.Now,
                Diagnose = basicMedicalNoteInfo.Diagnose
            };

            medicalNoteService.AddMedicalNote(medicalNoteDTO);
            return Ok();
        }
    }
}
