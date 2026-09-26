using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DigitalMarketDBContext _context;
        private readonly UserManager<IdentityUser> UserManager;
        public HomeController(DigitalMarketDBContext context, UserManager<IdentityUser> usermanager)
        {
            _context = context;
            this.UserManager = usermanager;
        }
        public IActionResult Index()
        {

            return View();

        }
        [Authorize]
        public IActionResult FinalCart()
        {

            string CurrentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            String[] s2 = new String[100];
            if (Request.Cookies.Keys.Contains("Cart"))
            {
                String Q = Request.Cookies["Cart"];
                int ArrayCount = Q.ToCharArray().Count(c => c == '-');
                for (int w = 0; w < ArrayCount; w++)
                {
                    s2[w] = Q.Substring(0, Q.IndexOf('-'));
                    Q = Q.Remove(0, Q.IndexOf('-') + 1);
                }

            }
            Random r = new Random();
            Order o = new Order();

            int OrderId = r.Next(0, 1000) + r.Next(1000, 1500);
            Order order = _context.Orders.SingleOrDefault(O => O.UserId == CurrentUserID && !O.IsFinaly);
            if (order == null)
            {
                o = new Order { OrderId = OrderId, CreateDate = DateTime.Now, UserId = CurrentUserID, IsFinaly = false };
                _context.Orders.Add(o);
                AddOrderDetails(s2, o, OrderId);
            }
            else
            {
                _context.Orders.Remove(order);
                o = new Order { OrderId = OrderId, CreateDate = DateTime.Now, UserId = CurrentUserID, IsFinaly = false, Sum = 0 };
                _context.Orders.Add(o);
                AddOrderDetails(s2, o, OrderId);
            }
            return View();
        }
        [HttpPost]
        public IActionResult InsertOrderInfo(Address A, string osta)
        {
            A.Date = System.DateTime.Now;
            A.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            A.Ostan = osta;
            A.OrderId = (_context.Orders.Where(a => a.UserId == A.UserId && !a.IsFinaly).SingleOrDefault()).OrderId;
            _context.Addresses.Add(A);
            (_context.Orders.Where(a => a.UserId == A.UserId && !a.IsFinaly).SingleOrDefault()).IsFinaly = true;
            _context.SaveChanges();
            Response.Cookies.Delete("Cart");
            return RedirectToAction("Index");
        }
        public void AddOrderDetails(string[] s2, Order o, int OrderId)
        {
            int sum = 0, TotalPrice = 0;

            if (s2 != null)
            {

                for (int i = 0; s2[i] != null; i++)
                {
                    String s = s2[i].ToString();
                    int id = Convert.ToInt32(s.Substring(0, s.IndexOf('Q')));
                    int count = Convert.ToInt32(s.Substring(s.IndexOf('_') + 1));
                    foreach (var item in _context.Products.Where(item => item.ProductId == id))
                    {
                        sum = count * Convert.ToInt32(item.Price);
                        OrderDetail OD = new OrderDetail { OrderId = OrderId, Count = count, Price = Convert.ToInt32(item.Price), ProductId = id };
                        _context.OrderDetails.Add(OD);
                    }
                    TotalPrice += sum;
                }
            }
            _context.SaveChanges();
            o.Sum = TotalPrice;
            _context.Orders.Update(o);
            _context.SaveChanges();
        }

        public IActionResult ShopingCart()
        {
            return View();

        }
        public IActionResult DigitalProducts()
        {

            return View(_context.Products);
        }

        public IActionResult CallUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CallUs(CallUs C)
        {
            C.IP = HttpContext.Connection.RemoteIpAddress.ToString();
            C.Date = DateTime.Now;
            _context.CallUs.Add(C);
            _context.SaveChanges();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
