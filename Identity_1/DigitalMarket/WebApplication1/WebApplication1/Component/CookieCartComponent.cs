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
    public class CookieCartComponent : ViewComponent
    {
        private readonly DigitalMarketDBContext _context;

        public CookieCartComponent(DigitalMarketDBContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
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
            List<ShowCartViewModel> _list = new List<ShowCartViewModel>();
            if (s2 != null)
            {

                for (int i = 0; s2[i] != null; i++)
                {
                    String s = s2[i].ToString();
                    int id = Convert.ToInt32(s.Substring(0, s.IndexOf('Q')));
                    int count = Convert.ToInt32(s.Substring(s.IndexOf('_') + 1));

                    foreach (var item in _context.Products.Where(item => item.ProductId == id))
                    {
                        _list.Add(new ShowCartViewModel()
                        {
                            Count = count,
                            Price = item.Price,
                            Title = item.Title,
                            ImageName = item.ImageName,
                            ProdectId = item.ProductId
                        });
                    }

                }

            }
           
            return View("/Views/Shared/_ShowCart2.cshtml", _list);
        }
    }
}
