using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using YoYoMooc.StudentManagement.Models;
using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteModel(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            Student deletedStudent = _studentRepository.Delete(Student.Id);

            if (deletedStudent == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Index");
        }
    }
}