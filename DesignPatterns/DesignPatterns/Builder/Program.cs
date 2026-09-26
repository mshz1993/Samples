using System;

// Product Class
class Course
{
    private string name;
    private string duration;
    private string level;

    // Constructor (private to enforce the builder pattern)
    private Course(CourseBuilder builder)
    {
        this.name = builder.Name;
        this.duration = builder.Duration;
        this.level = builder.Level;
    }

    // Getters
    public string GetName()
    {
        return name;
    }

    public string GetDuration()
    {
        return duration;
    }

    public string GetLevel()
    {
        return level;
    }

    // Static Builder Class
    public class CourseBuilder
    {
        public string Name { get; private set; }
        public string Duration { get; private set; }
        public string Level { get; private set; }

        public CourseBuilder SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public CourseBuilder SetDuration(string duration)
        {
            this.Duration = duration;
            return this;
        }

        public CourseBuilder SetLevel(string level)
        {
            this.Level = level;
            return this;
        }

        public Course Build()
        {
            return new Course(this);
        }
    }
}

// Main Class
class BuilderPatternExample
{
    static void Main(string[] args)
    {
        // Creating a ScholarHat course using the Builder Pattern
        Course javaCourse = new Course.CourseBuilder()
            .SetName("Java Programming")
            .SetDuration("6 months")
            .SetLevel("Intermediate")
            .Build();

        // Displaying course details
        Console.WriteLine("Course Name: " + javaCourse.GetName());
        Console.WriteLine("Duration: " + javaCourse.GetDuration());
        Console.WriteLine("Level: " + javaCourse.GetLevel());

        // Creating another course
        Course pythonCourse = new Course.CourseBuilder()
            .SetName("Python Programming")
            .SetDuration("4 months")
            .SetLevel("Beginner")
            .Build();

        // Displaying course details
        Console.WriteLine("\nCourse Name: " + pythonCourse.GetName());
        Console.WriteLine("Duration: " + pythonCourse.GetDuration());
        Console.WriteLine("Level: " + pythonCourse.GetLevel());
    }
}