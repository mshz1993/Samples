namespace EFSample
{
    public class CourseTeachers
    {
        public int CourseTeachersId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher  Teacher { get; set; }
        public int SortOrder { get; set; }
    }
}
