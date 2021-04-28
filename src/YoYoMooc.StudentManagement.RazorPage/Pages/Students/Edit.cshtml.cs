using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YoYoMooc.StudentManagement.Models;
using YoYoMooc.StudentManagement.Services;

namespace YoYoMooc.StudentManagement.RazorPage.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IStudentRepository studentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //这是显示模板将用于的属性,显示现有的学生数据
        [BindProperty]
        public Student Student { get; set; }

// 我们使用这个属性来存储和处理新上传的照片
        [BindProperty]
        [Display(Name = "照片信息")]
        public IFormFile Photo { get; set; }



        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }



        public IActionResult OnGet(int id)
        {

            Student = _studentRepository.GetStudent(id);

            if (Student == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "您已经打开了消息通知功能";
            }
            else
            {
                Message = "你已经关闭了消息通知功能";
            }


            //将确认消息存储在TempData中
            TempData["Message"] = Message;
           

            // 将请求重定向到Details razor页面，并传递StudentId 
            //StudentId作为路由参数传递  
            return RedirectToPage("Details", new { id = id });
            
        }




        public IActionResult OnPost(Student student)
        {

            if (ModelState.IsValid)
            {

          



            if (Photo != null)
            {
                //上传新照片的时候，需要检查当前学生是否有已经存在的照片，如果有的话，就需要删除它，再上传新照片。
                if (student.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        "images", student.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                // 将新照片保存到wwwroot/images文件夹中，并更新student 的PhotoPath属性
                student.PhotoPath = ProcessUploadedFile();
                }
           
            Student = _studentRepository.Update(student); 
                
                return RedirectToPage("Index");
            }
            return Page();

          
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;           

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}