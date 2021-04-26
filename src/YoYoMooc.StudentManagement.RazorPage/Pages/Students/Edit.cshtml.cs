using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YoYoMooc.StudentManagement.Models;
using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public EditModel(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        //这是显示模板将用于的属性,显示现有的学生数据
        public Student Student { get; set; }


        public IActionResult OnGet(int id)
        {
            Student = _studentRepository.GetStudent(id);

            if (Student == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

    }
}
