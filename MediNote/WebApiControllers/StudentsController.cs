using MediNote.Auth;
using MediNote.ErrorCodes;
using MediNote.Errors;
using MediNote.Filters;
using MediNote.Models;
using Microsoft.AspNet.Identity;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace MediNote.WebApiControllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : BaseApiController
    {
        StudentService studentService;
        private AuthRepository authRepository;

        public StudentsController()
        {
            studentService = new StudentService();
            authRepository = new AuthRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Student")]
        [Route("{studentNIN:length(10)}")]
        public IHttpActionResult GetStudent(string studentNIN)
        {
            if (User.Identity.Name != studentNIN && User.IsInRole("Student"))
            {
                return new UnauthorizedWithHttpError(Request, ErrorCode.StudentsCanOnlyGetTheirInformation);
            }

            var student = studentService.GetStudentByNIN(studentNIN);

            if (student == null)
            {
                return new BadRequestWithHttpError(Request, ErrorCode.StudentNotFoundWithThisNIN);
            }

            return Ok(student);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        [Route("")]
        [ValidateModel]
        public async Task<IHttpActionResult> AddStudent([FromBody] StudentDTO studentInfo)
        {
            UserModel userModel = new UserModel()
            {
                Username = studentInfo.StudentNIN,
                Password = studentInfo.StudentNIN
            };

            IdentityResult result = await authRepository.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result, ErrorCode.AccountAlreadyExistsWithThisNIN);

            if (errorResult != null)
            {
                return errorResult;
            }

            var user = await authRepository.UserManager.FindByNameAsync(userModel.Username);

            if (user == null)
            {
                return InternalServerError();
            }

            IdentityResult addRoleResult = await authRepository.UserManager.AddToRoleAsync(user.Id, "Student");

            errorResult = GetErrorResult(addRoleResult, ErrorCode.StudentCouldNotBeAddedToRole);

            if (errorResult != null)
            {
                return errorResult;
            }

            var studentService = new StudentService();
            studentService.AddStudent(studentInfo);

            return Ok();
        }
    }
}
