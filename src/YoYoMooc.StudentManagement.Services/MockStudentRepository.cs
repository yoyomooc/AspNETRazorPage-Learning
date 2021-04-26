using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YoYoMooc.StudentManagement.Models;

namespace YoYoMooc.StudentManagement.Services
{

    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                 new Student() { Id = 1, Name = "张三", Major = MajorEnum.ComputerScience, Email = "Tony-zhang@52abp.com" },
            new Student() { Id = 2, Name = "李四", Major = MajorEnum.ElectronicCommerce, Email = "lisi@52abp.com" },
            new Student() { Id = 3, Name = "王二麻子", Major = MajorEnum.Mathematics, Email = "wang@52abp.com" },

            };
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(e => e.Id == id);
        }
    }
}
