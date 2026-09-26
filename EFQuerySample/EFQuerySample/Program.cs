using EfSample.DAL;
using Microsoft.EntityFrameworkCore;

var optionBuilder = new DbContextOptionsBuilder<CourseeStoreDBContext>();
optionBuilder.UseSqlServer("Server=.;Database=CourseeDb;Integrated Security=True;TrustServerCertificate=true;");

using CourseeStoreDBContext dBContext = new CourseeStoreDBContext(optionBuilder.Options);
 CourseStoreRepository repository = new CourseStoreRepository(dBContext);

repository.GetCourses();

Console.ReadKey();



Employee.include(c => c.Children).Tolist().Where(c => !c.Parentid.hasvalue);




class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public int?       ParentId { get; set; }
    public List<Employee> Children { get; set; }

}