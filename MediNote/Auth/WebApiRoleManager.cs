using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediNote.Auth
{
    public class WebApiRoleManager : RoleManager<IdentityRole>
    {
        public WebApiRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static WebApiRoleManager Create(IdentityFactoryOptions<WebApiRoleManager> options, IOwinContext context)
        {
            ///It is based on the same context as the ApplicationUserManager
            var appRoleManager = new WebApiRoleManager(new RoleStore<IdentityRole>(context.Get<AuthContext>()));
            return appRoleManager;
        }
    }
}