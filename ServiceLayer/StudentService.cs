using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    public class StudentService
    {

        MediNoteEntities StudentContext = new MediNoteEntities();

        public void AddStudent(StudentDTO newStudentInfo)
        {
            StudentContext.spAddStudent(newStudentInfo.StudentNIN, newStudentInfo.StudentName,
                newStudentInfo.StudentAddress, newStudentInfo.StudentAge);            
        }

        public StudentDTO GetStudentByID(int studentID)
        {
            var returnedStudent = StudentContext.student_table.Find(studentID);

            if (returnedStudent == null)
            {
                return null;
            }

            StudentDTO studentDTO = new StudentDTO();
            studentDTO.StudentAddress = returnedStudent.StudentAddress;
            studentDTO.StudentAge = returnedStudent.StudentAge;
            studentDTO.StudentName = returnedStudent.StudentName;
            studentDTO.StudentNIN = returnedStudent.StudentNIN;
            studentDTO.Id = returnedStudent.ID;

            return studentDTO;
        }

        public StudentDTO GetStudentByNIN(string studentNIN)
        {
            var returnedStudent = StudentContext.spGetStudentByNIN(studentNIN).FirstOrDefault();

            if (returnedStudent == null)
            {
                return null;
            }

            StudentDTO studentDTO = new StudentDTO();
            studentDTO.StudentAddress = returnedStudent.StudentAddress;
            studentDTO.StudentAge = returnedStudent.StudentAge;
            studentDTO.StudentName = returnedStudent.StudentName;
            studentDTO.StudentNIN = returnedStudent.StudentNIN;
            studentDTO.Id = returnedStudent.ID;

            return studentDTO;
        }

        public void DeleteStudentByID(int studentID)
        {
            StudentContext.spDeleteStudent(studentID);

        }

        public void UpdateStudentByID(int studentID, StudentDTO updateStudentInfo)
        {
            StudentContext.spUpdateStudent(studentID, updateStudentInfo.StudentNIN,
                updateStudentInfo.StudentName, updateStudentInfo.StudentAddress,
                updateStudentInfo.StudentAge);           
        }

    }
}
