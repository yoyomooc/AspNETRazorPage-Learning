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

    }
}
