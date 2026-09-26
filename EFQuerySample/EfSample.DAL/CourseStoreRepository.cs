using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfSample.DAL
{
    public class CourseStoreRepository
    {
        private readonly CourseeStoreDBContext dbContext;

        public CourseStoreRepository(CourseeStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void PrintCourseAndThechears()
        {
            var result = dbContext.Courses.Include(c => c.CourseTeachers).ThenInclude(c=>c.Teacher).ToList();
            var result_02 = dbContext.Courses
                .Include(c => c.CourseTeachers)
                .ThenInclude(c=>c.Teacher)
                .Include(c=>c.Tags)         
                .ToList();

            var result_03 = dbContext.Courses
             .Include(c => c.CourseTeachers.OrderBy(c=>c.SortOrder))
             .ThenInclude(c =>c.Teacher)
             .Include(c => c.Tags)
             .ToList();

            var result_04= dbContext.Courses
           .Include(c => c.CourseTeachers.OrderBy(c => c.SortOrder))
           .ThenInclude(c => c.Teacher)
           .Include(c => c.Tags.Take(2))
           .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"Course is {course.Name}");
                foreach (var teacher in course.CourseTeachers)
                {
                    Console.WriteLine($"Teacher is {teacher.Teacher.FirstName} {teacher.Teacher.LastName}");
                }
            }
        }
        public void PrintCourseAndThechearsExplicit()
        {
            var courses = dbContext.Courses.ToList();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course is {course.Name}");

                dbContext.Entry(course).Collection(c => c.CourseTeachers).Load();

                foreach (var courseTeachers in course.CourseTeachers)
                {
                    dbContext.Entry(courseTeachers).Reference(c => c.Teacher).Load();

                    Console.WriteLine($"Teacher is {courseTeachers.Teacher.FirstName} {courseTeachers.Teacher.LastName}");
                }
            }
        }
        public void PrintCourseAndThechearsSelectLoading()
        {
            var courses = dbContext.Courses;

            foreach (var course in courses)
            {
                Console.WriteLine($"Course is {course.CourseId} {course.Name}");

                foreach (var teacher in course.CourseTeachers)
                {
                    Console.WriteLine($"Teacher  is {teacher.TeacherId}");

                }
            }
        }
        public void GetCourses()
        {

            var courses = dbContext.Courses.AsNoTrackingWithIdentityResolution().Include(c=>c.CourseTeachers).ThenInclude(c=>c.Teacher).ToList();
            var t1c7 = courses.Where(c => c.CourseId == 7).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;
            var t1c8 = courses.Where(c => c.CourseId == 8).FirstOrDefault().CourseTeachers.FirstOrDefault().Teacher;

            Console.WriteLine(object.ReferenceEquals(t1c7, t1c8));

        }
    }
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
