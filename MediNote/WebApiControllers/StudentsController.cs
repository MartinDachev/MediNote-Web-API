using MediNote.Auth;
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
                // TODO: Add message
                return Unauthorized();
            }

            var student = studentService.GetStudentByNIN(studentNIN);

            if (student == null)
            {
                return new BadRequestWithMessageResult("Student not found with this NIN");
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
                UserNIN = studentInfo.StudentNIN,
                Password = studentInfo.StudentNIN
            };

            IdentityResult result = await authRepository.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            var user = await authRepository.UserManager.FindByNameAsync(userModel.UserNIN);

            if (user == null)
            {
                return InternalServerError();
            }

            IdentityResult addRoleResult = await authRepository.UserManager.AddToRoleAsync(user.Id, "Student");

            errorResult = GetErrorResult(addRoleResult);

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
