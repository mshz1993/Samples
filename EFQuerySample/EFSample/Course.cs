using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<CourseTeachers> CourseTeachers { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment>  Comments { get; set; }
        public Discount  Discount { get; set; }

    }
}
