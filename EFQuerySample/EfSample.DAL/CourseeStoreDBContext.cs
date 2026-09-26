using EFSample;
using Microsoft.EntityFrameworkCore;

namespace EfSample.DAL
{
    public class CourseeStoreDBContext : DbContext
    {
        #region DbSets
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTeachers> CourseTeachers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        #endregion
        #region Constructor
        public CourseeStoreDBContext(DbContextOptions<CourseeStoreDBContext> options) : base(options)
        {
        }
        #endregion
        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        } 
        #endregion
    }
}