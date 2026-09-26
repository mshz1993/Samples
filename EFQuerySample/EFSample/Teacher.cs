namespace EFSample
{
    public class Teacher
    {
        public int Teacherid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CourseTeachers> CourseTeachers { get; set; }

    }
}
