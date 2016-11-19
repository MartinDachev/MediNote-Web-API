using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ServiceLayer
{
    class StudentService
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
            StudentDTO objDto = new StudentDTO();
            objDto.StudentAddress = returnedStudent.StudentAddress;
            objDto.StudentAge = returnedStudent.StudentAge;
            objDto.StudentName = returnedStudent.StudentName;
            objDto.StudentNIN = returnedStudent.StudentNIN;

            return objDto;
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
