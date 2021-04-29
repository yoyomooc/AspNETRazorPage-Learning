using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using YoYoMooc.StudentManagement.Models;
using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IStudentRepository _studentRepository;

        public HeadCountViewComponent(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IViewComponentResult Invoke(MajorEnum? Major = null)
        {
            var result = _studentRepository.StudentCountByMajorEnum(Major);
            return View(result);
        }
    }
}
