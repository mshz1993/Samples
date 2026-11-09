using EFSample;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EfSample.DAL
{
    public class Linq_Samples
    {
        private readonly CourseeStoreDBContext dbContext;

        public Linq_Samples(CourseeStoreDBContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void Test_1()
        {
            var totalAmount = dbContext.Orders
                   .Where(o => o.CustomerId == 1)
                   .Sum(o => o.Amount);
            Console.WriteLine(totalAmount);


            var orderList = dbContext.Orders.Where(x => x.Amount > 500000).ToList();
            Order[] order = dbContext.Orders.Where(x => x.CustomerId == 10).ToArray();

            //کلید Id
            var customers1 = dbContext.Customers.ToDictionary(x => x.Id,x => x);
            var Cust1_1 = customers1[1];



            //کلید Customer
            //var customers2 = dbContext.Customers.ToDictionary(x => x,x => x.Id);
            //var Cust2_1 = customers2[new Customer { Id = 2 }];



            //کلید Id به دلیل پیش فرض بودن نیازی به نوشتن Customer نیس
            var customers3 = dbContext.Customers.ToDictionary(x => x.Id);
            var Cust3_1 = customers3[2];



            if(customers3.TryGetValue(15,out var customer))
            {
                // کلید وجود دارد
            }
            else
            {
                // کلید وجود ندارد
            }

            var lookup = dbContext.Orders
                .ToLookup(x => x.CustomerId);

            var customerOrders = lookup[10];

            var totalAmount2 = lookup[10].Sum(x => x.Amount);
        }

        public void Test_2()
        {
            // Linq Method Syntax  

            var Method_Syntax_1 = dbContext.Orders
                                   .Where(x => x.Amount > 500)
                                   .OrderBy(x => x.Amount)
                                   .Select(x => x.Amount);



            var Method_Syntax_2 = dbContext.Orders
                                           .Join(
                                               dbContext.Customers,
                                               order => order.CustomerId,
                                               customer => customer.Id,
                                               (order,customer) => new
                                               {
                                                   customer.Name,
                                                   order.Amount
                                               });



            // Linq Query Syntax
            var QuerySyntax_1 =
                       from order in dbContext.Orders
                       where order.Amount > 500
                       orderby order.Amount
                       select order.Amount;



            var QuerySyntax_2 =
                        from order in dbContext.Orders
                        join customer in dbContext.Customers
                            on order.CustomerId equals customer.Id
                        select new
                        {
                            customer.Name,
                            order.Amount
                        };
        }
        public void Test_3()
        {
            //Lambda,Expression,Func

            Func<Order,bool> FuncCondition = x => x.Amount > 500;

            var result1 = dbContext.Orders
                .AsEnumerable()
                .Where(FuncCondition);


            Expression<Func<Order,bool>> ExpressionCondition = x => x.Amount > 500;

            var result2 = dbContext.Orders
                .Where(ExpressionCondition);


            //اگر منبع IEnumerable باشد،
            //معمولاً لامبدا به شکل Func استفاده می‌شود؛
            //اگر منبع IQueryable باشد،
            //معمولاً به شکل Expression<Func<...>> دریافت می‌شود.
            var Test_1 = dbContext.Orders
                                  .Where(x => x.Amount > 500)
                                  .OrderBy(x => x.Amount)
                                  .Select(x => x.Amount);


            //IEnumerable=>FuncCondition Is Best
            //اجرای شرط روی داده‌های موجود در حافظه
            var IE_Orders = dbContext.Orders.ToList();

            var result_1 = IE_Orders.Where(FuncCondition);
            var result_2 = IE_Orders.Where(ExpressionCondition.Compile());




            //IQueryable=>ExpressionCondition Is Best
            //امکان ترجمه شرط به SQL و اجرای فیلتر در دیتابیس
            IQueryable<Order> IQ_Orders = dbContext.Orders;

            var result_4 = IQ_Orders.Where(ExpressionCondition);



            //چون condition از نوع Func است، نسخه Where مربوط به IEnumerable انتخاب می‌شود.
            //EF Core دیگر شرط را به SQL تبدیل نمی‌کند.
            //ابتدا سفارش‌ها از دیتابیس خوانده می‌شوند.
            // سپس شرط در حافظه اجرا می‌شود.
            var result_3 = IQ_Orders.Where(FuncCondition);
        }

        public void Test_4()
        {
            // Deferred Execution (اجرای با تأخیر)
            IQueryable<Order> query = dbContext.Orders
                                      .Where(x => x.Amount > 500);
            //Run Query
            foreach(var order in query)
            {
                Console.WriteLine(order.Amount);
            }

            //Where، Select و OrderBy Is Deferred Execution



            //Immediate Execution (اجرای فوری)
            var orders = dbContext.Orders
                        .Where(x => x.Amount > 500)
                        .ToList();

            //ToList()، ToArray()، Count() و First() Is Immediate Execution




            var result = dbContext.Orders
                        .Where(x => x.Amount > 500)
                        .ToList();

            var result1 = result;
            var result2 = result;
        }

        public void Test_5()
        {
            var customers = new List<Customer>
                  {
                      new Customer
                      {
                          Name = "Ali",
                          Orders = new List<Order>
                          {
                              new Order { Amount = 100 },
                              new Order { Amount = 200 }
                          }
                      },
                      new Customer
                      {
                          Name = "Reza",
                          Orders = new List<Order>
                          {
                              new Order { Amount = 300 },
                              new Order { Amount = 400 }
                          }
                      }
                  };


            var result1 = customers.Select(x => x.Orders);
            //Output:  [[100,200],[300,400]]

            var result2 = customers.SelectMany(x => x.Orders);
            //Output:[100,200,300,400]
        }

        public void Test_6()
        {
            //Projection:Select Many Property Not all 

            var result = dbContext.Customers
                                  .Select(x => new // Anonymous Types - Output Type
                                  {
                                      x.Id,
                                      x.Name,
                                      OrderCount = x.Orders.Count()
                                  })
                                  .ToList();
        }
        public void Test_7()
        {
            //Linq to DTO
            var result = dbContext.Customers
                                  .Select(x => new CustomerReportDto
                                  {
                                      CustomerId = x.Id,
                                      CustomerName = x.Name,
                                      OrderCount = x.Orders.Count()
                                  })
                                  .ToList();

        }
        public void Test_8()
        {
            //Entity State:Tracking , AsNoTracking


            var customer = dbContext.Customers
                                    .FirstOrDefault(x => x.Id == 1);
            //Unchanged
            var state1 = dbContext.Entry(customer).State;


            customer.Name = "Mehran";

            //Modified
            var state2 = dbContext.Entry(customer).State;

            //AsNoTracking: Just for read data
            var customers = dbContext.Customers
                                     .AsNoTracking()
                                     .ToList();

            //Solution1: for save change in AsNoTracking mode  in database 
            dbContext.Customers.Update(customer);
            dbContext.SaveChanges();



            //Solution2: for save change in AsNoTracking mode  in database 
            dbContext.Customers.Attach(customer);

            //Set property to just update this 
            dbContext.Entry(customer)
                .Property(x => x.Name)
                .IsModified = true;

            dbContext.SaveChanges();


            var customers2 = dbContext.Customers
                                  .AsNoTracking()
                                  .Include(x => x.Orders)
                                  .ToList();


            var orders_1 = dbContext.Orders
                                  .Where(x => x.CustomerId == 1)
                                  .Include(x => x.Customer)
                                  .AsNoTrackingWithIdentityResolution()
                                  .ToList();
            //True
            Console.WriteLine(orders_1[0].Customer.Id == orders_1[1].Customer.Id);

            //True
            Console.WriteLine(
                ReferenceEquals(
                    orders_1[0].Customer,
                    orders_1[1].Customer
                )
            );


            var orders_2 = dbContext.Orders
                                .Where(x => x.CustomerId == 1)
                                .Include(x => x.Customer)
                                .AsNoTracking()
                                .ToList();

            //True
            Console.WriteLine(orders_1[0].Customer.Id == orders_1[1].Customer.Id);

            //False
            Console.WriteLine(
                ReferenceEquals(
                    orders_1[0].Customer,
                    orders_1[1].Customer
                )
            );


        }

        public void Test_9()
        {
            //Best Practice
            var result = dbContext.Customers
                                  .Join(
                                      dbContext.Orders,
                                      customer => customer.Id,
                                      order => order.CustomerId,
                                      (customer,order) => new
                                      {
                                          CustomerId = customer.Id,
                                          CustomerName = customer.Name,
                                          order.Amount
                                      })
                                  .Where(x => x.Amount > 1000)
                                  .GroupBy(x => new
                                  {
                                      x.CustomerId,
                                      x.CustomerName
                                  })
                                  .Select(g => new
                                  {
                                      CustomerId = g.Key.CustomerId,
                                      CustomerName = g.Key.CustomerName,
                                      TotalAmount = g.Sum(x => x.Amount),
                                      OrderCount = g.Count()
                                  })
                                  .Where(x => x.TotalAmount > 5000)
                                  .ToList();


            //Order Count Without Join
            var result2 = dbContext.Customers
                                  .Select(x => new
                                  {
                                      x.Name,
                                      OrderCount = x.Orders.Count()
                                  })
                                  .ToList();


            var result3 = dbContext.Orders
                .Join(dbContext.Customers,o => o.CustomerId,c => c.Id,(o,c) =>
                 new
                 {
                     CustomerName = c.Name,
                     CustomerId = c.Id,
                     o.Amount
                 })
                .Where(x => x.Amount > 1000)
                .GroupBy(x => new
                {
                    x.CustomerId,
                    x.CustomerName
                })
                .Select(x => new
                {
                    x.Key.CustomerId,
                    x.Key.CustomerName,
                    OrderCount = x.Count(),
                    TotalAmount = x.Sum(x => x.Amount)
                }
                )
               .Where(x => x.TotalAmount > 5000)

                .ToList();





            var result4 = dbContext.Customers
                .GroupJoin(dbContext.Orders,c => c.Id,o => o.CustomerId,(customer,orders) => new { customer,orders })
                .SelectMany
                (
                           x => x.orders.DefaultIfEmpty(),
                           (x,o) => new
                           {
                               CustomerId = x.customer.Id,
                               CustomerName = x.customer.Name,
                               Amount = o == null ? (decimal?)null : o.Amount
                           }
                )
                .Where(x => x.Amount == null || x.Amount > 500)
                .GroupBy(x => new
                {
                    x.CustomerId,
                    x.CustomerName,

                })
                .Select(x => new
                {
                    x.Key.CustomerId,
                    x.Key.CustomerName,
                    OrderCount = x.Count(x => x.Amount != null),
                    TotalAmount = x.Sum(x => x.Amount)
                })
                .Where(x => x.OrderCount >= 2)
                .ToList();



            var result6 = dbContext.Customers.GroupJoin(
                dbContext.Orders,c => c.Id,o => o.CustomerId,(customer,orders) =>
                new
                {
                    customer,
                    orders
                })
                .SelectMany
                (
                             x => x.orders.DefaultIfEmpty(),
                             (c,o) =>
                             new
                             {
                                 c.customer.Id,
                                 c.customer.Name,
                                 Amount = o == null ? (decimal?)null : o.Amount

                             }
                )
                .Where(x => x.Amount == null || x.Amount > 1000)
                .GroupBy(x => new
                {
                    x.Id,
                    x.Name

                })
                .Select
                (
                x => new
                {
                    CustomerId = x.Key.Id,
                    CustomerName = x.Key.Name,
                    OrderCount = x.Count(),
                    TotalAmount = x.Sum(x => x.Amount),
                    MaxAmount = x.Max(x => x.Amount)
                }
                )
                .Where(x => x.TotalAmount > 3000)
                .ToList();






        }


        public class CustomerReportDto
        {
            public int CustomerId
            {
                get; set;
            }
            public string CustomerName
            {
                get; set;
            }
            public int OrderCount
            {
                get; set;
            }
        }
    }
}
