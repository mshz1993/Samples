using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Data;
using WebApplication1.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace WebApplication1.Controllers
{
  
    public class OrdersController : Controller
    {
        private DigitalMarketDBContext _Context;

        public OrdersController(DigitalMarketDBContext context)
        {
            _Context = context;
        }

        public IActionResult Delete(int id)
        {
            var RequestedAddress = Request.Headers["Referer"].ToString();
            if (Request.Cookies.Keys.Contains("Cart"))
            {
                int i;
                String Q = Request.Cookies["Cart"];
                String Final = null;
                int ArrayCount = Q.ToCharArray().Count(c => c == '-');
                String[] s = new String[ArrayCount];
                for (int w = 0; w < ArrayCount; w++)
                {
                    s[w] = Q.Substring(0, Q.IndexOf('-'));
                    Q = Q.Remove(0, Q.IndexOf('-') + 1);
                }
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i].IndexOf(id.ToString(), 0) != -1)
                    {

                        s[i] = null;
                        for (int y = i+1; y < s.Length; y++)
                        {
                            s[i] = s[y];
                            s[y] = null;
                            i++;
                        }
                        TempData["Message"] = "محصول با موفقیت حذف شد";
                        break;
                    }
                }
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i] != null)
                    {
                        Final = Final + s[i] + "-";
                    }

                }
                if (Final == null)
                {
                    Response.Cookies.Delete("Cart");
                }
                else

                    Response.Cookies.Append("Cart", Final);
                TempData["AA"] = s;
            }
          

            return Redirect(RequestedAddress);
        }
        //[HttpPost]
        public IActionResult Add(int number1, int Mines)
        {
            var RequestedAddress = Request.Headers["Referer"].ToString();
            String[] s = new String[100];
            if (Request.Cookies.Keys.Contains("Cart"))
            {
                int i, k = 0;
                String Q = Request.Cookies["Cart"];
                String Final = null;
                int ArrayCount = Q.ToCharArray().Count(c => c == '-');
                for (int w = 0; w < ArrayCount; w++)
                {
                    s[w] = Q.Substring(0, Q.IndexOf('-'));
                    Q = Q.Remove(0, Q.IndexOf('-') + 1);
                }
                for (i = 0; s[i] != null; i++)
                {
                    if (s[i].IndexOf(number1.ToString(), 0) != -1 && Mines == 0)
                    {
                        k = 1;
                        int L = s[i].LastIndexOf("_");
                        String e = s[i].Substring(L + 1);
                        int count = Convert.ToInt32(e) + 1;
                        s[i] = s[i].Remove(L + 1);
                        s[i] = s[i].Insert(L + 1, count.ToString());
                        TempData["Message"] = "تعداد محصول مورد نظر 1 واحد افزایش یافت";
                    }
                    else if (s[i].IndexOf(number1.ToString(), 0) != -1 && Mines == 1)
                    {
                        k = 1;
                        int L = s[i].LastIndexOf("_");
                        String e = s[i].Substring(L + 1);
                        if (Convert.ToInt32(e) > 1)
                        {
                            int count = Convert.ToInt32(e) - 1;
                            s[i] = s[i].Remove(L + 1);
                            s[i] = s[i].Insert(L + 1, count.ToString());
                            TempData["Message"] = "تعداد محصول مورد نظر 1 واحد کاهش یافت";


                        }
                        else
                            TempData["Error"] = "تعداد کالا نمیتواند از 1 عدد کمتر باشد";

                    }
                }
                if (k == 0)
                {
                    s[i] = number1.ToString() + "Q_1";
                    TempData["Message"] = "محصول مورد نظر با موفقیت به سبد خرید افزوده شد";

                }
                for (i = 0; s[i] != null; i++)
                {
                    Final = Final + s[i] + "-";
                }
                Response.Cookies.Append("Cart", Final);
            }
            else
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("Cart", number1.ToString() + "Q_1-");
                TempData["Message"] = "محصول مورد نظر با موفقیت به سبد خرید افزوده شد";

            }
            if (s[0] == null)
            {
                s[0] = number1.ToString() + "Q_1";
            }
            TempData["AA"] = s;

            return Redirect(RequestedAddress);
        }



        //public IActionResult AddToCart(int id, int Negetive)
        //{
        //    string CurrentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Order order = _Context.Orders.SingleOrDefault(o => o.UserId == CurrentUserID && !o.IsFinaly);
        //    if (order == null)
        //    {
        //        order = new Order()
        //        {
        //            UserId = CurrentUserID,
        //            CreateDate = DateTime.Now,
        //            IsFinaly = false,
        //            Sum = 0
        //        };

        //        _Context.Orders.Add(order);
        //        _Context.OrderDetails.Add(new OrderDetail()
        //        {
        //            OrderId = order.OrderId,
        //            Count = 1,
        //            Price = _Context.Products.Find(id).Price,
        //            ProductId = id
        //        });
        //        _Context.SaveChanges();
        //    }
        //    else
        //    {
        //        var details = _Context.OrderDetails.SingleOrDefault(d => d.OrderId == order.OrderId && d.ProductId == id);
        //        if (details == null)
        //        {
        //            _Context.OrderDetails.Add(new OrderDetail()
        //            {
        //                OrderId = order.OrderId,
        //                Count = 1,
        //                Price = _Context.Products.Find(id).Price,
        //                ProductId = id
        //            });
        //        }

        //        else if (Negetive == 0)
        //        {
        //            details.Count += 1;
        //            _Context.Update(details);
        //        }

        //        if (Negetive == 1 && details.Count > 1)
        //        {
        //            details.Count -= 1;
        //            _Context.Update(details);
        //        }
        //        else
        //            TempData["Error"] = "مقدار کالا نباید از 1 عدد کمتر باشد";

        //        _Context.SaveChanges();
        //    }
        //    UpdateSumOrder(order.OrderId);
        //    return RedirectToAction("DigitalProducts", "Home");
        //}
        //public IActionResult DeleteFromCart(int id, int Negetive)
        //{
        //    string CurrentUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    Order order = _Context.Orders.SingleOrDefault(o => o.UserId == CurrentUserID && !o.IsFinaly);
        //    if (order != null)
        //    {
        //        var details = _Context.OrderDetails.SingleOrDefault(d => d.OrderId == order.OrderId && d.ProductId == id);
        //        _Context.OrderDetails.Remove(details);
        //        _Context.SaveChanges();

        //    }
        //    UpdateSumOrder(order.OrderId);
        //    return RedirectToAction("DigitalProducts", "Home");
        //}

        //public void UpdateSumOrder(int orderId)
        //{
        //    var order = _Context.Orders.Find(orderId);
        //    order.Sum = _Context.OrderDetails.Where(o => o.OrderId == order.OrderId).Select(d => d.Count * d.Price).Sum();
        //    _Context.Update(order);
        //    _Context.SaveChanges();
        //}
    }
}