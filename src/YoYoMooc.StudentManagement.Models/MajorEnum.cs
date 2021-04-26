using System.ComponentModel.DataAnnotations;

namespace YoYoMooc.StudentManagement.Models
{
    public enum MajorEnum
    {
        [Display(Name = "未分配")]
        None,

        [Display(Name = "计算机科学")]
        ComputerScience,

        [Display(Name = "电子商务")]
        ElectronicCommerce,

        [Display(Name = "数学")]
        Mathematics
    }
}