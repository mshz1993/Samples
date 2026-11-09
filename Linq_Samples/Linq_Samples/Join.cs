
internal class Program_2
    {
    public static void Main()
        {
        var users = new[]
             {
                 new { Name = "Ali", DepartmentId = 1  },
                 new { Name = "Sara", DepartmentId = 2 },
                 new { Name = "Reza", DepartmentId = 1 }
             };

        var departments = new[]
  {
    new { Id = 1, Title = "IT" },
    new { Id = 2, Title = "HR" },
    new { Id = 4, Title = "Finance" }
};


        var result = users.Join(
                  departments,
                  u => u.DepartmentId,
                  d => d.Id,
                  (u, d) => new
                      {
                      UserName = u.Name,
                      DepartmentName = d.Title
                      });




        var employees = new[]
    {
    new { Name = "Ali", DepartmentId = 1, Salary = 30000 },
    new { Name = "Sara", DepartmentId = 2, Salary = 40000 },
    new { Name = "Reza", DepartmentId = 1, Salary = 35000 },
    new { Name = "Mina", DepartmentId = 3, Salary = 45000 }
};


        var result2 = employees.Join(departments, e => e.DepartmentId, d => d.Id, (e, d) => new
            {
            e.Name,
            e.Salary,
            DepartmentName = d.Title
            })
            .Where(e => e.Salary > 35000)
            .Select(x => new { x.Name, x.DepartmentName });

       
        
        
        //Left Join Classic
        var result3 = employees
    .GroupJoin(
        departments,
        e => e.DepartmentId,
        d => d.Id,
        (e, deptGroup) => new { e, deptGroup })
    .SelectMany(
        x => x.deptGroup.DefaultIfEmpty(),
        (x, d) => new
            {
            x.e.Name,
            x.e.Salary,
            DepartmentName = d == null ? null : d.Title
            });





        //Group Join 
        var result34 = departments.GroupJoin(
     employees,
     d => d.Id,
     e => e.DepartmentId,
     (d, employeeGroup) => new
         {
         DepartmentName = d.Title,
         Employees = employeeGroup.Select(e => e.Name).ToList(),
         EmployeeCount = employeeGroup.Count()
         });


        var result5 = departments.GroupJoin(
    employees,
    d => d.Id,
    e => e.DepartmentId,
    (d, group) => new
        {
        Department = d.Title,
        EmployeeCount = group.Count()
        });







        var customers = new[]
{
    new { Id = 1, Name = "Ali" },
    new { Id = 2, Name = "Sara" },
    new { Id = 3, Name = "Reza" }
};

        var orders = new[]
        {
    new { Id = 101, CustomerId = 1, Amount = 500 },
    new { Id = 102, CustomerId = 1, Amount = 300 },
    new { Id = 103, CustomerId = 2, Amount = 700 }
};



        var res = customers.GroupJoin(orders, c => c.Id, o => o.CustomerId, (c,o) => new
            {
            CustomerName = c.Name,
            OrderCount = o.Count(),
            TotalAmount = o.Sum(s => s.Amount)
            });




//Classic Left Join
        var result6 = customers
    .GroupJoin(
        orders,
        c => c.Id,
        o => o.CustomerId,
        (c, group) => new { c, group })
    .SelectMany(
        x => x.group.DefaultIfEmpty(),
        (x, o) => new
            {
            CustomerName = x.c.Name,
            OrderAmount = o == null ? (int?)null : o.Id
            });




        }

    }