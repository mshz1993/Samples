using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Component
{
    public class CartComponent : ViewComponent
    {
        private readonly DigitalMarketDBContext _context;

        public CartComponent(DigitalMarketDBContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ShowCartViewModel> _list = new List<ShowCartViewModel>();

            if (User.Identity.IsAuthenticated)
            {
                string CurrentUserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var order = _context.Orders.SingleOrDefault(o => o.UserId == CurrentUserID && !o.IsFinaly);
                if (order != null)
                {
                    var details = _context.OrderDetails.Where(d => d.OrderId == order.OrderId).ToList();
                    foreach (var item in details)
                    {
                        var product = _context.Products.Find(item.ProductId);
                        _list.Add(new ShowCartViewModel()
                        {
                            Count = item.Count,
                            Title = product.Title,
                            ImageName = product.ImageName,
                            ProdectId = product.ProductId
                        });

                    }
                }

            }

            return View("/Views/Shared/_ShowCart.cshtml", _list);
        }

    }
}
