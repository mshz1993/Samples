using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class HeaderMenu
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد عنوان الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد لینک الزامی است")]
        [Display(Name = "لینک")]
        public string Link { get; set; }
        public Nullable<int> ParentID { get; set; }
        [Display(Name = "ترتیب")]
        public Nullable<int> Sort { get; set; }
        public Nullable<bool> IsDynamic { get; set; }
        public string ControlName { get; set; }

    }
}
