using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Address
    {

        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد نام الزامی است")]
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد تلفن تماس الزامی است")]
        [Display(Name = "تلفن تماس")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد شهر و استان الزامی است")]
        [Display(Name = "شهر")]
        public string City { get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد استان الزامی است")]
        [Display(Name = "استان")]
        public string Ostan{ get; set; }
        [Required(ErrorMessage = "تکمیل  فیلد آدرس الزامی است")]
        [Display(Name = "آدرس")]
        public string Addresss { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
