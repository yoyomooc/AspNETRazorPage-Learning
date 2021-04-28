using System;
using System.Collections.Generic;
using System.Text;

using YoYoMooc.StudentManagement.Models;

namespace YoYoMooc.StudentManagement.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        Student Update(Student updatedStudent);

        Student Add(Student newStudent);
    }
 
}
