using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;

namespace MediNote.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }


        //[Route(“student /{studentID}”)]
        public ActionResult GetStudentByID(int studentID)
        {
            StudentService objStudent = new StudentService();
            StudentDTO returnedStudent = objStudent.GetStudentByID(studentID);
            return View(returnedStudent);
        }

    }
}