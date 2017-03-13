using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediNote.Constants
{
    public static class UserRoleOptions
    {
        public static string Admin
        {
            get { return "Admin"; }
        }

        public static string Doctor
        {
            get { return "Doctor"; }
        }

        public static string Student
        {
            get { return "Student"; }
        }

        public static string AllRoles
        {
            get { return "Admin,Doctor,Student"; }
        }
    }
}