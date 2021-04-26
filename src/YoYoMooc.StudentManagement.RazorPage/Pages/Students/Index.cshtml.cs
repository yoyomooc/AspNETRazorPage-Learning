using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using YoYoMooc.StudentManagement.Models;
using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// //这个公共属性保存学生列表 显示模板(Index.html)可以访问此属性
        /// </summary>
        public IEnumerable<Student> Students { get; set; }


        /// <summary>
        /// 注册IStudentRepository服务。通过这项服务知道如何查询学生列表
        /// </summary>
        /// <param name="studentRepository"></param>
        public IndexModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// 此方法处理发送GET请求 到路由 /Students/Index  
        /// </summary>
        public void OnGet()
        {
            Students = _studentRepository.GetAllStudents();
        }
    }
}
