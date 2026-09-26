using System;
// Abstract Product Interfaces
interface ICourse
{
    void GetCourseDetails();
}

interface ICertification
{
    void GetCertificationDetails();
}



// Abstract Factory Interface
interface ICourseFactory
{
    ICourse CreateCourse();
    ICertification CreateCertification();
}




// Concrete Products for Java
class JavaCourse : ICourse
{
    public void GetCourseDetails()
    {
        Console.WriteLine("offers an in-depth Java course.");
    }
}

class JavaCertification : ICertification
{
    public void GetCertificationDetails()
    {
        Console.WriteLine("provides Java Certification after course completion.");
    }
}


// Concrete Products for C#
class CsharpCourse : ICourse
{
    public void GetCourseDetails()
    {
        Console.WriteLine("offers an in-depth C# course.");
    }
}

class CsharpCertification : ICertification
{
    public void GetCertificationDetails()
    {
        Console.WriteLine("provides C# Certification after course completion.");
    }
}



// Concrete Factories
class JavaFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new JavaCourse();
    }

    public ICertification CreateCertification()
    {
        return new JavaCertification();
    }
}

class CsharpFactory : ICourseFactory
{
    public ICourse CreateCourse()
    {
        return new CsharpCourse();
    }

    public ICertification CreateCertification()
    {
        return new CsharpCertification();
    }
}


// Main Class
class Program
{
    static void Main(string[] args)
    {
        // Creating Java factory
        ICourseFactory factory = new JavaFactory();

        ICourse course = factory.CreateCourse();
        ICertification certification = factory.CreateCertification();

        course.GetCourseDetails();
        certification.GetCertificationDetails();

        // Creating C# factory

        factory = new CsharpFactory();

        course = factory.CreateCourse();
        certification = factory.CreateCertification();

        course.GetCourseDetails();
        certification.GetCertificationDetails();

    }
}