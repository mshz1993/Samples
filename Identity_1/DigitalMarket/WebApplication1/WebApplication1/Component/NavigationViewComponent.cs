using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Component
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly DigitalMarketDBContext _context;

        public NavigationViewComponent(DigitalMarketDBContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            TempData["MenuList"] = _context.HeaderMenus.Where(a => a.ParentID == 1 && a.ParentID != a.Id).OrderBy(a => a.Sort);
            return View();
        }
    }
}

