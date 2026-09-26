using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CallUs
    {
        public int id { get; set; }
        [Required(ErrorMessage ="تکمیل  فیلد عنوان الزامی است")]
        [Display(Name="عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد نام الزامی است")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد تلفن تماس الزامی است")]
        [Display(Name = "تلفن تماس")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد توضیحات الزامی است")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        public string IP { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        public bool Read { get; set; }

    }
}
