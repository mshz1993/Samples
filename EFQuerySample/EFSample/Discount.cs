using System.ComponentModel.DataAnnotations.Schema;

namespace EFSample
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public int CourseId { get; set; }
        public Course  Course { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal NewPrice { get; set; }
    }
}
