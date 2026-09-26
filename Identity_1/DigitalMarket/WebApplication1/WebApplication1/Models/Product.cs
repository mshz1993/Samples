using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="افزودن فیلد عنوان الزامی است")]
        [MaxLength(300,ErrorMessage ="حداکثر کاراکتر ورودی فیلد عنوان 300 می باشد")]
        [Display(Name ="عنوان")]
        public string Title { get; set; }
        [Required(ErrorMessage = "افزودن فیلد متن الزامی است")]
        [Display(Name = "متن")]
        public string Text { get; set; }
        [Required(ErrorMessage = "افزودن فیلد قیمت الزامی است")]
        [Display(Name = "قیمت")]
        public string Price { get; set; }
        [Required(ErrorMessage = "افزودن فیلد عکس الزامی است")]
        [Display(Name = "عکس")]
        public string ImageName { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
