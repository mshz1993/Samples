using EfSample.DAL;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseeStoreDBContext>();
optionBuilder.UseSqlServer("Server=.;Database=CourseeDb;Integrated Security=True;TrustServerCertificate=true;");

using CourseeStoreDBContext dBContext = new CourseeStoreDBContext(optionBuilder.Options);
CourseStoreRepository repository = new CourseStoreRepository(dBContext);
Linq_Samples linq = new Linq_Samples(dBContext);

linq.Test_9();
Console.ReadKey();




class Employee
{
    public int Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string Family
    {
        get; set;
    }
    public int? ParentId
    {
        get; set;
    }
    public List<Employee> Children
    {
        get; set;
    }

}


