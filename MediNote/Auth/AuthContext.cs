using MediNote.Auth.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediNote.Auth
{
    public class AuthContext : IdentityDbContext<WebApiUser>
    {
        public AuthContext()
            : base("AuthContext")
        {
        }
    }
}