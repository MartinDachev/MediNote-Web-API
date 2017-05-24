using MediNote.Auth;
using MediNote.Errors;
using MediNote.Filters;
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
    [RoutePrefix("api/Accounts")]
    public class AccountsController : BaseApiController
    {
        private AuthRepository authRepository;

        public AccountsController()
        {
            authRepository = new AuthRepository();
        }

        // POST api/Account/Register
        [Authorize(Roles = "Admin")]
        [ValidateModel]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            IdentityResult result = await authRepository.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor,Student")]
        [ValidateModel]
        [Route("GetType")]
        public async Task<IHttpActionResult> GetAccountType()
        {
            if (User.IsInRole("Admin"))
            {
                return Ok(new { AccountType = "Admin" });
            }

            if (User.IsInRole("Doctor"))
            {
                return Ok(new { AccountType = "Doctor"});
            }

            if (User.IsInRole("Student"))
            {
                return Ok(new { AccountType = "Student" });
            }

            return BadRequest();
        }

        [Authorize(Roles = "Admin")]
        [Route("users/{id:guid}/roles")]
        [HttpPost]
        public async Task<IHttpActionResult> AssignRolesToUser(string id, string roleToAssign)
        {
            if (roleToAssign == null)
            {
                return this.BadRequest("No roles specified");
            }
            
            ///find the user we want to assign roles to 
            var appUser = await authRepository.UserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            ///check if the user currently has any roles 
            var currentRoles = await authRepository.UserManager.GetRolesAsync(appUser.Id);
            var roleExists = await authRepository.RoleManager.RoleExistsAsync(roleToAssign);
            if (!roleExists)
            {
                ModelState.AddModelError("", string.Format("Role '{0}' does not exist in the system", roleToAssign));
                return this.BadRequest(ModelState);
            }
            ///remove user from current roles, if any
            IdentityResult removeResult = await authRepository.UserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());
            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }
            ///assign user to the new roles 
            IdentityResult addResult = await authRepository.UserManager.AddToRolesAsync(appUser.Id, roleToAssign);
            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok(new { userId = id, rolesAssigned = roleToAssign });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                authRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
