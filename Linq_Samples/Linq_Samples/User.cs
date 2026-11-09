public class User
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }
    }

//internal class Program
//    {
//    public static void Main()
//        {
//        var users = new List<User>
//              {
//                  new User { Name = "Ali", Department = "IT" },
//                  new User { Name = "Sara", Department = "HR" },
//                  new User { Name = "Reza", Department = "IT" },
//                  new User { Name = "Mina", Department = "HR" }
//              };



//        //var first_User = users.First(x => x.Id == 2);
//        //var firstOrDefault_User = users.FirstOrDefault(x => x.Id == 2);
//        //var single_User = users.Single(x => x.Id == 2);
//        //var singleOrDefault_User = users.SingleOrDefault(x => x.Id == 2);



//        var sortedUser = users.OrderBy(x => x.Id).ThenBy(x => x.Name);



//        var groupBy = users.GroupBy(x => x.Department);

//        foreach (var group in groupBy)
//            {
//            Console.WriteLine(group.Key);

//            foreach (var user in group)
//                {
//                Console.WriteLine(user.Name);
//                }
//            }


//        var numbers = new List<int> { 10, 20, 10, 30, 20, 10 };


//        var result = numbers
//               .GroupBy(x => x)
//               .Select(g => new
//                   {
//                   Number = g.Key,
//                   Count = g.Count()
//                   });


//        var result2 = numbers
//        .GroupBy(x => x)
//        .Select(g => new
//            {
//            Number = g.Key,
//            Sum = g.Sum()
//            });

//        }
//    }