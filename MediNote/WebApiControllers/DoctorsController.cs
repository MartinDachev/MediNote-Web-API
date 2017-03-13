using ServiceLayer;
using System.Web.Http;
using MediNote.Errors;
using Microsoft.AspNet.Identity;
using MediNote.Auth;
using System.Threading.Tasks;
using MediNote.Filters;

namespace MediNote.WebApiControllers
{
    [RoutePrefix("api/doctors")]
    public class DoctorsController : BaseApiController
    {
        private DoctorService doctorsService = new DoctorService();
        private AuthRepository authRepository = new AuthRepository();

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        [Route("{doctorNIN:length(10)}")]
        public IHttpActionResult GetDoctor(string doctorNIN)
        {
            if (User.Identity.Name != doctorNIN && !User.IsInRole("Admin"))
            {
                // TODO: Add message
                return Unauthorized();
            }
            
            var doctor = doctorsService.GetDoctorByNIN(doctorNIN);
            if (doctor == null)
            {
                return new BadRequestWithMessageResult("Doctor not found with this NIN");
            }
            return Ok(doctor);
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        [Route("")]
        public async Task<IHttpActionResult> AddDoctor([FromBody] DoctorRegistrationDTO doctorInfo)
        {
            UserModel userModel = new UserModel()
            {
                UserNIN = doctorInfo.DoctorNIN,
                Password = doctorInfo.Password
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

            IdentityResult addRoleResult = await authRepository.UserManager.AddToRoleAsync(user.Id, "Doctor");

            errorResult = GetErrorResult(addRoleResult);

            if (errorResult != null)
            {
                return errorResult;
            }
            
            HealthCareFacilitiesService facilityService = new HealthCareFacilitiesService();
            var facility = facilityService.GetFacilityByName(doctorInfo.HealthcareFacilityName);

            if (facility == null)
            {
                facilityService.AddHealthcareFacilite(doctorInfo.HealthcareFacilityName);
            }

            facility = facilityService.GetFacilityByName(doctorInfo.HealthcareFacilityName);

            var doctor = new DoctorDTO()
            {
                DoctorNIN = doctorInfo.DoctorNIN,
                DoctorName = doctorInfo.DoctorName,
                DoctorEmail = doctorInfo.DoctorEmail,
                DoctorPhoneNumber = doctorInfo.DoctorPhoneNumber,
                DoctorPosition = doctorInfo.DoctorPosition,
                DoctorUIN = doctorInfo.DoctorUIN,
                HealthcareFacilityId = facility.Id
            };

            var doctorService = new DoctorService();
            doctorsService.AddDoctor(doctor);

            return Ok();
        }
    }
}
