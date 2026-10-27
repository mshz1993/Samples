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

//GroupJoin
var GroupJoin = customers.GroupJoin(
    orders,
    c => c.Id,
    o => o.CustomerId,
    (c, group) => new
    {
        CustomerName = c.Name,
        Orders = group
    });

foreach (var item in GroupJoin)
    foreach (var order in item.Orders)
    {
        Console.WriteLine($"{item.CustomerName} - {order.Amount}");
    }




//Left Join
var LeftJoin = customers
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
            OrderAmount = o == null ? (int?)null : o.Amount
        });

foreach (var item in LeftJoin)
{
    Console.WriteLine($"{item.CustomerName} - {item.OrderAmount}");
}



var res = customers
    .GroupJoin(orders,
    customers => customers.Id,
    order => order.CustomerId,
    (customer, orderGroup) => new { customer, orderGroup })

    .Select(x
      => new
      {
          CustomerName = x.customer.Name,
          OrderCount = x.orderGroup.Count(),
          TotalAmount = x.orderGroup.Sum(o => o.Amount)
      });


foreach (var item in res)
{
    Console.WriteLine($"{item.CustomerName} - {item.OrderCount}- {item.TotalAmount}");
}



var custs = customers.GroupJoin(orders,
    customers => customers.Id,
    orders => orders.CustomerId,
    (customer, orders) => new { customer, orders })
    .Select(x => new
    {
        CustomerName = x.customer.Name,
        OrderCount = x.orders.Count(),
        TotalAmount = x.orders.Sum(o => o.Amount)
    })
    .Where(x => x.TotalAmount > 500)
    .OrderByDescending(x => x.TotalAmount);


foreach (var item in custs)
{
    Console.WriteLine($"{item.CustomerName} - {item.OrderCount}- {item.TotalAmount}");
}


var departmentIds = new[] { 1, 2, 1, 3, 2, 4, 3, 5 };


var result2 = departmentIds.Distinct();



//var list1 = new[] { 10, 20, 30 };
//var list2 = new[] { 30, 40, 50 };

////مجموع بدون تکراری
//var result=list1.Union(list2);


var list1 = new[] { 10, 20, 30, 40 };
var list2 = new[] { 30, 40, 50, 60 };
//عناصر مشترک مجموعه
var result = list1.Intersect(list2);



// عناصری رو برمی‌گردونه که در مجموعه اول هستن، اما در مجموعه دوم نیستن.
var resultww = list1.Except(list2);


// دو مجموعه رو پشت سر هم قرار می‌ده برخلاف Union، تکراری‌ها رو حذف نمی‌کنه.

var resultddd = list1.Concat(list2);


var numbersList = new[] { 5, 10, 15, 20, 25, 30, 35, 40 };

var result333=numbersList.Skip(2).Take(3);

var numbers = new[] { 10, 25, 15, 40, 30, 5 };

var result22322 = numbers.Last(x => x > 20);
var result223222 = numbers.LastOrDefault(x => x > 20);


var element1 = numbers.ElementAt(2);
var element2 = numbers.ElementAtOrDefault(2);

