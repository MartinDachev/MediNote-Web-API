using MediNote.Auth.Models;
using MediNote.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MediNote.Auth
{
    public class AuthRepository : IDisposable
    {
        public  UserManager<WebApiUser> UserManager { get; private set; }

        public WebApiRoleManager RoleManager { get; private set; }

        public AuthContext Context { get; private set; }

        public AuthRepository()
        {
            Context = new AuthContext();
            UserManager = new UserManager<WebApiUser>(new UserStore<WebApiUser>(Context));
            RoleManager = new WebApiRoleManager(new RoleStore<IdentityRole>(Context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            WebApiUser user = new WebApiUser()
            {
                UserName = userModel.UserNIN
            };

            var result = await UserManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<WebApiUser> FindUser(string userName, string password)
        {
            WebApiUser user = await UserManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            Context.Dispose();
            UserManager.Dispose();
        }
    }
}