using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using YoYoMooc.StudentManagement.Models;
using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public DetailsModel(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public Student Student { get; set; }
        /// <summary>
        /// //模型绑定自动映射查询字符串id的值，映射到OnGet()方法上的设置为id参数
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);
        }
    }
}
